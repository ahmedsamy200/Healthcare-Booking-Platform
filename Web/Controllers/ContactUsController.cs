using AutoMapper;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Web.Models;

namespace Web.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IContactUsService _contactUsService;
        private readonly IMapper _mapper;

        public ContactUsController(IContactUsService contactUsService , IMapper mapper)
        {
            _contactUsService = contactUsService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<JsonResult> GetAllMassages()
        {
            IEnumerable<ContactUs> massages = await _contactUsService.GetAll();
            var massagesViewModel = _mapper.Map<IEnumerable<ContactUsViewModel>>(massages);
            return Json(massagesViewModel.ToList().OrderByDescending(x => x.Id));
        }


        [HttpPost]
        public async Task<JsonResult> AddMassage(ContactUsViewModel contactUsViewModel)
        {
            try
            {
                var contactUs = _mapper.Map<ContactUs>(contactUsViewModel);
                var result =  await _contactUsService.Add(contactUs);
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
    }
}
