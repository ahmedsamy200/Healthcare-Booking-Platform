using Microsoft.AspNetCore.Mvc;
using Web.Models;
using Service.Interface;
using AutoMapper;
using Domain;

namespace Web.Controllers
{
    public class OffersController : Controller
    {

        private readonly IOfferService _offerService;
        private readonly IOfferPhotosService _offerPhotosService;
        private readonly IDoctorAppointmentsService _doctorAppointmentsService;
        private readonly IMapper _mapper;
        public OffersController(IOfferService offerService,
               IOfferPhotosService offerPhotosService,
               IDoctorAppointmentsService doctorAppointmentsService,
               IMapper mapper)
        {
            _offerService = offerService;
            _offerPhotosService = offerPhotosService;
            _doctorAppointmentsService = doctorAppointmentsService;
            _mapper = mapper;

        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Offer> Offers =await _offerService.GetAllOffers();
            var offersVM = _mapper.Map<IEnumerable<OfferViewModel>>(Offers);


            return View(offersVM);
        }

        public async Task<IActionResult> Offer(int id)
        {
            try
            {
                if (id > 0)
                {
                    var offer = await _offerService.GetOfferById(id);
                    if (offer == null)
                    {
                        return RedirectToAction("Index");

                    }
                    var offerVM = _mapper.Map<OfferViewModel>(offer);
                    ViewBag.offerPhotos = _offerPhotosService.GetOfferPhotosById(id).Result;
                    ViewBag.DoctorAppointments = _doctorAppointmentsService.GetDoctorAppointments(offerVM.doctorID).Result;

                    return View(offerVM);
                }
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<JsonResult> GetAllOffers()
        {
            IEnumerable<Offer> offers = await _offerService.GetAllOffers();
            var offersViewModel = _mapper.Map<IEnumerable<OfferViewModel>>(offers);
            return Json(offersViewModel.ToList().OrderByDescending(x => x.Id));
        }

        public async Task<IActionResult> AddOffer()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                    return View();

                }
                return RedirectToAction("Index", "Offers");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> MyOffers()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                    int doctorID = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));

                    IEnumerable<Offer> Offers = await _offerService.GetDoctorOffers(doctorID);
                    var offersVM = _mapper.Map<IEnumerable<OfferViewModel>>(Offers);
                    return View(offersVM);

                }
                return RedirectToAction("Index", "Offers");

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<JsonResult> AddOffer(OfferViewModel offerVM , IFormFile mainPhotoUploaded, List<IFormFile> offerPhotos)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    /// Upload main photo
                    var fileName = Guid.NewGuid() + Path.GetExtension(mainPhotoUploaded.FileName);
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\offers", fileName);

                    using (var fileStream = new FileStream(filePath , FileMode.Create))
                    {
                        await mainPhotoUploaded.CopyToAsync(fileStream);
                    }


                    var offer = _mapper.Map<Offer>(offerVM);

                    offer.mainPhoto = fileName;
                    offer.doctorID = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));

                    var result =  await _offerService.AddOffer(offer);


                    ///Upload offer Photos
                    foreach (var file in offerPhotos)
                    {
                        OfferPhotos obj = new OfferPhotos();

                        var fName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\offers", fName);
                        var stream = new FileStream(path, FileMode.Create);
                        file.CopyToAsync(stream);

                        obj.offerID = result.Id;
                        obj.image = fName;
                        await _offerPhotosService.AddOfferPhotos(obj);

                    }
                 
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
        public async Task<JsonResult> DeleteOffer(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json("error");

                }
                 if(DeleteOfferPhotos(id).Result)
                {
                    var result =await _offerService.DeleteOffer(id);
                    if (result)
                    {
                        return Json("success");
                    }

                }


                return Json("error");

            }
            catch (System.Exception)
            {
                return Json("error");
            }
        }


        private async Task<bool> DeleteOfferPhotos(int id)
        {
            var result = await _offerPhotosService.DeleteOfferPhotos(id);
            if (result.Count() > 0)
            {
                foreach (var item in result)
                {
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", item.image);
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);

                }
                return true;

            }
            return false;
        }

    }
}
