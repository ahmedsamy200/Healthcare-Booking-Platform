using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Web.Models;

namespace Web.Controllers
{
    public class AppointmentsController : Controller
    {

        private readonly IDoctorAppointmentsService _doctorAppointmentsService;
        private readonly IAppointmentService _appointmentsService;
        private readonly IMapper _mapper;

        public AppointmentsController(
            IDoctorAppointmentsService doctorAppointmentsService,
            IAppointmentService appointmentsService,
            IMapper mapper)
        {
            _doctorAppointmentsService = doctorAppointmentsService;
            _appointmentsService = appointmentsService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                    return View();

                }
                return RedirectToAction("Login", "Doctors");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult AddAppointments()
        {

            try
            {
                if (HttpContext.Session.GetString("DoctorID") != null)
                {
                    return View();

                }
                return RedirectToAction("Login", "Doctors");
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult> UserAppointments()
        {
            try
            {
                if (HttpContext.Session.GetString("UserID") != null)
                {
                    var userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                    var appointments = await _appointmentsService.GetUserAppointments(userID);
                    var appointmentViewModel = _mapper.Map<IEnumerable<AppointmentsViewModel>>(appointments);
                    return View(appointmentViewModel);

                }
                return RedirectToAction("Login", "User");
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<ActionResult> BookAppointment(int id)
        {

            try
            {
                if (HttpContext.Session.GetString("UserID") != null)
                {
                    var appointment = await _doctorAppointmentsService.GetAppointmentByID(id);
                    var appointmentViewModel = _mapper.Map<DoctorAppointmentsViewModel>(appointment);
                    return View(appointmentViewModel);

                }
                return RedirectToAction("Login", "User");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<ActionResult> BookOffer(int doctorID)
        {

            try
            {
                if (HttpContext.Session.GetString("UserID") != null)
                {
                    var appointments = await _doctorAppointmentsService.GetDoctorAppointments(doctorID);
                    var appointmentsViewModel = _mapper.Map<IEnumerable<DoctorAppointmentsViewModel>>(appointments);
                    return View(appointmentsViewModel);

                }
                return RedirectToAction("Login", "User");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<JsonResult> BookAppointment(AppointmentsViewModel appointmentsViewModel)
        {

            try
            {
                var userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));
                appointmentsViewModel.userID = userID;
                var appointment = _mapper.Map<Appointments>(appointmentsViewModel);
                var availableAppointment = await _appointmentsService.AvailableAppointment(appointment);
                if (availableAppointment)
                {
                    if (await _appointmentsService.AddAppointments(appointment))
                    {
                        return Json("success");

                    }
                    return Json("failed");

                }
                return Json("notAvailable");
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpPost]
        public async Task<JsonResult> AddAppointments([FromBody] List<DoctorAppointmentsViewModel> doctorAppointments)
        {

            try
            {
                int doctorID = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));

                await _doctorAppointmentsService.DeleteAppointment(doctorID);

                var Appointments = _mapper.Map<IEnumerable<DoctorAppointments>>(doctorAppointments);

                foreach (var item in Appointments)
                {
                  item.doctorID = doctorID;     
                  await _doctorAppointmentsService.AddDoctorAppointments(item);

                }
                return Json("success");

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<JsonResult> GetDoctorAppointments()
        {

            try
            {
                int doctorID = Convert.ToInt32(HttpContext.Session.GetString("DoctorID"));

                var appoiontments =await _doctorAppointmentsService.GetDoctorAppointments(doctorID);
                var appoiontmentsViewModel = _mapper.Map<IEnumerable<DoctorAppointmentsViewModel>>(appoiontments);
                return Json(appoiontmentsViewModel.ToList());
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<JsonResult> GetDayHours(string dayAr , int doctorID)
        {

            try
            {

                var appoiontment =await _doctorAppointmentsService.GetAppointmentByDay(dayAr,doctorID);

                return Json(GetHours(appoiontment));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static List<DateTime?> GetHours(DoctorAppointments appointment)
        {
            List<DateTime?> times = new List<DateTime?>();
            var from = appointment.from;
            var to = appointment.to;
            var duration = appointment.duration;
            if (from.Value.Hour < to.Value.Hour)
            {
                for (var i = from; i <= to; i = i.Value.AddMinutes(30))
                {
                    times.Add(i);
                }

            }
            return times;
        }


        [HttpPost]
        public async Task<JsonResult> DeleteAppointment(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json("error");

                }
                var result = await _appointmentsService.DeleteAppointment(id);
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

    }
}
