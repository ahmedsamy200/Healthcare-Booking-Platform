using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ICityService _cityService;
        private readonly ISpecializationService _specializationService;
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        public HomeController(IDoctorService doctorService,
               ISpecializationService specializationService,
               ICityService cityService,
               IOfferService offerService,
               IMapper mapper)
        {
            _doctorService = doctorService;
            _specializationService = specializationService;
            _cityService = cityService;
            _offerService = offerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.cities = await _cityService.GetAllCities();
                ViewBag.specializations = await _specializationService.GetAllSpecializations();
                ViewBag.doctors = await _doctorService.GetAllDoctors();

                var offers =await _offerService.GetTopOffers();
                var result = _mapper.Map<IEnumerable<OfferViewModel>>(offers);
                return View(result);
            }
            catch (Exception)
            {

                throw;
            }
            
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}