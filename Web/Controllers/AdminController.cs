using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Web.Models;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISpecializationService _specialization;
        private readonly ICityService _cityService;

        private readonly IMapper _mapper;
        public AdminController(ISpecializationService specialization ,ICityService cityService, IMapper mapper)
        {
            _specialization = specialization;
            _cityService = cityService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("admin") == "admin@123admin")
            {
                return View();

            }  

            return View("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {

            if (model.email == "admin@admin.com" && model.password == "admin")
            {
                HttpContext.Session.SetString("admin", "admin@123admin");

              return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Doctor()
        {
            if (HttpContext.Session.GetString("admin") == "admin@123admin")
            {
                return View();

            }

            return View("Login");
        }   
        public IActionResult Offers()
        {
            if (HttpContext.Session.GetString("admin") == "admin@123admin")
            {
                return View();

            }

            return View("Login");
        }  
        public IActionResult Massages()
        {
            if (HttpContext.Session.GetString("admin") == "admin@123admin")
            {
                return View();

            }

            return View("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin");
            return RedirectToAction("Index" , "Home");
        }

        #region Specialization Actions

        [HttpPost]
        public async Task<JsonResult> AddSpecialization(SpecializationViewModel specialization)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var result = _mapper.Map<Specialization>(specialization);

                    // cheack if there are a specialization with the same name
                    if (_specialization.IsExist(result).Result)
                    {
                        return Json("exist");
                    }
                    await _specialization.AddSpecialization(result);
                    return Json("success");

                }
                return Json("error");
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<JsonResult> GetAllSpecializations()
        {
            IEnumerable<Specialization> specializations = await _specialization.GetAllSpecializations();
            var specializationViewModel = _mapper.Map<IEnumerable<SpecializationViewModel>>(specializations);
            return Json(specializationViewModel.ToList().OrderByDescending(x => x.Id));
        }

        public async Task<JsonResult> GetSpecializationByID(int id)
        {
            Specialization specialization = await _specialization.GetSpecializationById(id);
            var specializationViewModel = _mapper.Map<SpecializationViewModel>(specialization);

            return Json(specializationViewModel);
        }

        public async Task<JsonResult> GetSpecializationByName(string name)
        {
            IEnumerable<Specialization> specializations = await _specialization.GetSpecializationByName(name);
            var specializationViewModel = _mapper.Map<IEnumerable<SpecializationViewModel>>(specializations);
            return Json(specializationViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateSpecialization(SpecializationViewModel specializationViewModel)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (specializationViewModel.Id <= 0)
                    {
                        return Json("error");
                    }

                    var specialization = _mapper.Map<Specialization>(specializationViewModel);
                    // cheack if there are a specialization with the same name
                    if (_specialization.IsExist(specialization).Result)
                    {
                        return Json("exist");
                    }

                    var result = await _specialization.UpdateSpecialization(specialization, specialization.Id);
                    if (result)
                    {
                        return Json("success");

                    }
                }
                catch (Exception)
                {

                    return Json("error");
                }
            }
            return Json("error");
        }

        [HttpPost]
        public async Task<JsonResult> DeleteSpecialization(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json("error");

                }
                var result = await _specialization.DeleteSpecialization(id);
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

        public async Task<JsonResult> GetAllCities()
        {
            IEnumerable<City> cities = await _cityService.GetAllCities();
            var citiesViewModel = _mapper.Map<IEnumerable<City>>(cities);
            return Json(citiesViewModel.ToList().OrderByDescending(x => x.Id));
        }

        #endregion


    }
}
