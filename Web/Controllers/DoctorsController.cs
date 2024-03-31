using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Web.Models;

namespace Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly IReviewService _reviewService;
        private readonly IClinicPhotosService _clinicPhotosService;
        private readonly IDoctorAppointmentsService _doctorAppointmentsService;
        private readonly IAppointmentService _appointmentsService;
        private readonly ISpecializationService _specializationService;
        private readonly ICityService _cityService;        
        private readonly IMapper _mapper;

        public DoctorsController(IDoctorService doctorService ,
            IReviewService reviewService ,
            IClinicPhotosService clinicPhotosService ,
            IDoctorAppointmentsService doctorAppointmentsService ,
            IAppointmentService appointmentsService ,
            ISpecializationService specializationService ,
            ICityService cityService ,
            IMapper mapper)
        {
            _doctorService = doctorService;
            _reviewService = reviewService;
            _clinicPhotosService = clinicPhotosService;
            _doctorAppointmentsService = doctorAppointmentsService;
            _appointmentsService = appointmentsService;
            _specializationService = specializationService;
            _cityService = cityService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string specialization, string city, string doctorName)
        {

            ViewBag.cities = await _cityService.GetAllCities();
            ViewBag.specializations = await _specializationService.GetAllSpecializations();
            var doctors =await _doctorService.FilterDoctors(specialization , 9999999 , 0 , "" ,city , doctorName);
            var doctorsViewModel = _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
            foreach (var item in doctorsViewModel)
            {
                item.ratting = await _reviewService.GetRating(item.Id);
                item.appointments = await _doctorAppointmentsService.GetDoctorAppointments(item.Id);

            }
            return View(doctorsViewModel);
        }

        public async Task<IActionResult> Doctor(int id)
        {
            var doctor = await _doctorService.GetDoctorById(id);
            var doctorVM = _mapper.Map<DoctorViewModel>(doctor);
            ViewBag.rating = await _reviewService.GetRating(id);
            ViewBag.clinicPhotos = await _clinicPhotosService.GetClinicPhotos(id);
            ViewBag.reviews = await _reviewService.GetDoctorReviews(id);
            ViewBag.DoctorAppointments = await _doctorAppointmentsService.GetDoctorAppointments(id);
            return View(doctorVM);
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Register()
        {
            ViewBag.specializations = await _specializationService.GetAllSpecializations();
            ViewBag.cities = await _cityService.GetAllCities();

            return View();
        }
        public IActionResult Appointments()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                    int id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));
                    var appointments = _appointmentsService.GetAppointments(id).Result;
                    var appointmentsViewModel = _mapper.Map<IEnumerable<AppointmentsViewModel>>(appointments);

                    return View(appointmentsViewModel);

                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IActionResult> UpdateAccount()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                    int id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));
                    var doctor = await _doctorService.GetDoctorById(id);
                    var doctorVM = _mapper.Map<DoctorViewModel>(doctor);

                    ViewBag.specializations = await _specializationService.GetAllSpecializations();

                    return View(doctorVM);

                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<IActionResult> ChangePassword()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                  
                    return View();

                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {

                throw;
            }

        }  
        
        public async Task<IActionResult> UpdateDetails()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                    int id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));
                    var doctor = await _doctorService.GetDoctorById(id);
                    var doctorVM = _mapper.Map<DoctorViewModel>(doctor);
                    ViewBag.cities = await _cityService.GetAllCities();

                    return View(doctorVM);

                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public async Task<IActionResult> Login(Doctor model)
        {
            try
            {
                var result = await _doctorService.Login(model);
                if (result != null)
                {
                    HttpContext.Session.SetString("DoctorID", result.Id.ToString());
                    HttpContext.Session.SetString("DoctorName", result.name.Split(' ')[0]);
                    //var firstName = result.name.Split(' ');
                    result.photo = result.photo ?? "default.jpg";
                    HttpContext.Session.SetString("DoctorPhoto", result.photo);

                    return RedirectToAction(nameof(Profile));
                }
                ViewBag.errormessage = "كلمة المرور غير صحيحة";
                return View();
            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public async Task<IActionResult> Profile()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {

                    int id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));
                    var doctor = await _doctorService.GetDoctorById(id);
                    var doctorVM = _mapper.Map<DoctorViewModel>(doctor);

                    ViewBag.rating = await _reviewService.GetRating(id);
                    ViewBag.clinicPhotos = await _clinicPhotosService.GetClinicPhotos(id);
                    ViewBag.reviews = await _reviewService.GetDoctorReviews(id);
                    ViewBag.DoctorAppointments = await _doctorAppointmentsService.GetDoctorAppointments(id);
                    return View(doctorVM);
                }
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {

                throw;
            }

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index" , "Home");
        }

        #region jsonActions

        public async Task<JsonResult> GetAllDoctors()
        {
            IEnumerable<Doctor> doctors = await _doctorService.GetAllDoctors();
            var doctorViewModel = _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
            return Json(doctorViewModel.ToList().OrderByDescending(x => x.Id));
        }

        public async Task<JsonResult> GetFilterdDoctors(string specialization  , int maxPrice, int minPrice, string orderBy, string gender , string city , string doctorName)
        {

            var doctors = await _doctorService.FilterDoctors(specialization, maxPrice, minPrice ,gender , city , doctorName);
            var doctorsViewModel = _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
            foreach (var item in doctorsViewModel)
            {
                item.ratting = await _reviewService.GetRating(item.Id);
                item.appointments = await _doctorAppointmentsService.GetDoctorAppointments(item.Id);
            }
                       
            if (orderBy == "price")
            {
                return Json(doctorsViewModel.OrderByDescending(x => x.price));

            }
            return Json(doctorsViewModel.OrderByDescending(x => x.ratting));
        }

        [HttpPost]
        public async Task<JsonResult> AddDoctor(DoctorViewModel doctorVM)
        {
            try
            {
                doctorVM.IsActive = true;
                var doctor = _mapper.Map<Doctor>(doctorVM);

                // cheack if there are a doctor with the same email
                if (_doctorService.IsExist(doctor).Result)
                {
                    return Json("exist");
                }
                if(await _doctorService.AddDoctor(doctor))
                  return Json("success");
              
                return Json("error");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<JsonResult> GetDoctorByID(int id)
        {
            Doctor doctor = await _doctorService.GetDoctorById(id);
            var doctorViewModel = _mapper.Map<DoctorViewModel>(doctor);

            return Json(doctorViewModel);
        }

        public async Task<JsonResult> GetDoctorByName(string name)
        {
            IEnumerable<Doctor> doctors = await _doctorService.GetDoctorByName(name);
            var doctorsViewModel = _mapper.Map<IEnumerable<DoctorViewModel>>(doctors);
            return Json(doctorsViewModel);
        }


        [HttpPost]
        public async Task<JsonResult> UpdateDoctor(DoctorViewModel doctorViewModel)
        {

           try
           {
                if (doctorViewModel.Id <= 0)
                {
                    return Json("error");
                }

                var doctor = _mapper.Map<Doctor>(doctorViewModel);
                // cheack if there are a specialization with the same name
                if (_doctorService.IsExist(doctor).Result)
                {
                    return Json("exist");
                }

                var result = await _doctorService.UpdateDoctor(doctor);
                if (result)
                {
                    return Json("success");

                }
                return Json("error");
           }
           catch (Exception)
           {

                return Json("error");
           }

        }


        [HttpPost]
        public async Task<JsonResult> DeleteDoctor(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json("error");

                }
         
                var result = await _doctorService.DeleteDoctor(id);
                if (result)
                {
                    return Json("success");

                }
                return Json("error");

            }
            catch (System.Exception)
            {
                return Json("error");
            }
        }

        public JsonResult GetAllAppointments()
        {
            try
            {

                int id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));
                var appointments = _appointmentsService.GetAppointments(id).Result;
                var appointmentsViewModel = _mapper.Map<IEnumerable<AppointmentsViewModel>>(appointments);

                return Json(appointmentsViewModel);
                           
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<JsonResult> UpdateStatus(int id , bool status)
        {
            try
            {
                if (id > 0)
                {
                    var appointments = _appointmentsService.UpdateStatus(id, status).Result;

                    if (appointments != null)
                    {
                        return Json("success");
                    }
                    return Json("error");
                }
                return Json("error");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<JsonResult> GetAppointmentsByName(string name)
        {
            var doctorID = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));
            IEnumerable<Appointments> appointments = await _appointmentsService.GetAppointmentsByName(name, doctorID);
            var appointmentsViewModels = _mapper.Map<IEnumerable<AppointmentsViewModel>>(appointments);
            return Json(appointmentsViewModels);
        }
   

        [HttpPost]
        public async Task<JsonResult> UpdateAccount(DoctorViewModel doctorViewModel, IFormFile photoUploaded)
        {
            try
            {

                var doctor = _mapper.Map<Doctor>(doctorViewModel);
                doctor.Id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));

                if (photoUploaded != null)
                {
                                    
                   doctor.photo = UploadPhoto(photoUploaded).Result;
                   DeleteOldPhoto(doctor.Id);
                    HttpContext.Session.SetString("DoctorPhoto", doctor.photo);

                }
                HttpContext.Session.SetString("DoctorName", doctor.name.Split(' ')[0]);

                var result = await _doctorService.UpdateDoctor(doctor);

                if (result)
                {
                    return Json("success");

                }

                  return Json("error");
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public async Task<JsonResult> ChangePassword(DoctorViewModel doctorViewModel)
        {
            try
            {
                var doctor = _mapper.Map<Doctor>(doctorViewModel);
                doctor.Id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));
                var result = await _doctorService.ChangePassword(doctor);

                if (result)
                {
                    return Json("success");

                }

                return Json("error");
            }
            catch (Exception)
            {

                throw;
            }
           
        }


        [HttpPost]
        public async Task<JsonResult> UpdateDetails(DoctorViewModel doctorViewModel, List<IFormFile> clinicPhotos)
        {
            try
            {
       
                var doctor = _mapper.Map<Doctor>(doctorViewModel);
                doctor.Id = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));

                var result = await _doctorService.UpdateDetails(doctor);
                if (clinicPhotos.Count() > 0)
                {
       

                    // Delete Old Clinic Photos
                    var ClinicPhotos = await _clinicPhotosService.DeleteClinicPhotos(doctor.Id);
                    if (ClinicPhotos.Count() > 0)
                    {
                        foreach (var item in ClinicPhotos)
                        {

                            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\clinics", item.image);
                            if (System.IO.File.Exists(imagePath))
                                System.IO.File.Delete(imagePath);
                        }

                    }

                    // AddClinicPhotos
                    foreach (var file in clinicPhotos)
                    {

                        ClinicPhotos obj = new ClinicPhotos();
                        var fName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\clinics", fName);

                        var stream = new FileStream(path, FileMode.Create);
                        await file.CopyToAsync(stream);
                        await stream.DisposeAsync();
                        obj.doctorID = doctor.Id;
                        obj.image = fName;
                        await _clinicPhotosService.AddClinicPhotos(obj);
                    }

                }

                return Json("success");

                
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public async Task<JsonResult> Register(DoctorViewModel doctorViewModel , IFormFile doctorPhotoUploaded)
        {
            try
            {

                var doctor = _mapper.Map<Doctor>(doctorViewModel);

                // cheack if there are a doctor with the same name
                if (_doctorService.IsExist(doctor).Result)
                {
                    return Json("exist");
                }
                doctor.photo =await UploadPhoto(doctorPhotoUploaded);
                await _doctorService.AddDoctor(doctor);
                return Json("success");

                
            }
            catch (Exception)
            {

                throw;
            }

        }


        public async Task<JsonResult> AddComment(Review review)
        {

            if (HttpContext.Session.GetString("UserID") != null)
            {
                review.userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                review.date = DateTime.Now;
                var exist =await _reviewService.AddedBefor(review);
                if (exist)
                {
                    return Json("AddedBefor");
                }
                else
                {
                    var result =await _reviewService.AddReview(review);
                    if (result)
                    {
                        return Json("success");
                    }
                    return Json("fail");
                }

            }
            else
            {
                return Json("GoToLogin");
            }

        }

        private async Task<string> UploadPhoto(IFormFile photoUploaded)
        {

            var fileName = Guid.NewGuid() + Path.GetExtension(photoUploaded.FileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\doctors", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await photoUploaded.CopyToAsync(fileStream);
            }

            return fileName;

        }

        private async Task<bool> DeleteOldPhoto(int id)
        {
            var result = await _doctorService.GetDoctorById(id);

            string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\doctors", result.photo);
            if (System.IO.File.Exists(imagePath))
            System.IO.File.Delete(imagePath);
            return true;
           
        }


        private void UploadClinicPhotos(int doctorID, List<IFormFile> clinicPhotos)
        {

            foreach (var file in clinicPhotos)
            {

                ClinicPhotos obj = new ClinicPhotos();
                var fName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\clinics", fName);

                var stream = new FileStream(path, FileMode.Create);
                file.CopyToAsync(stream);
                stream.DisposeAsync();
                obj.doctorID = doctorID;
                obj.image = fName;
                _clinicPhotosService.AddClinicPhotos(obj);
            }

        }

        private void DeleteClinicPhotos(int id)
        {
            var result = _clinicPhotosService.DeleteClinicPhotos(id).Result;
            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\clinics", item.image);
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);

                }

            }
        }


        #endregion
    }


}
