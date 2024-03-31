using Domain;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Web.Models;
using AutoMapper;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;


        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        
        public IActionResult Profile()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Users()
        {
            if (HttpContext.Session.GetString("admin") == "admin@123admin")
            {
                return View();
            }

            return RedirectToAction("Index" , "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }



        public async Task<JsonResult> GetAllUsers()
        {
            IEnumerable<User> users = await _userService.GetAllUsers();
            var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return Json(usersViewModel.ToList().OrderByDescending(x => x.Id));
        }

        public async Task<JsonResult> GetUserByID(int id)
        {
            User user = await _userService.GetUserById(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return Json(userViewModel);
        }

        public async Task<JsonResult> GetUserByName(string name)
        {
            IEnumerable<User> users = await _userService.GetUserByName(name);
            var usersViewModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return Json(usersViewModel);
        }


        [HttpPost]
        public async Task<JsonResult> AddUser(UserViewModel userVM)
        {
            try
            {

                var user = _mapper.Map<User>(userVM);

                if (_userService.IsExist(user).Result)
                {
                    return Json("exist");
                }
                if (await _userService.AddUser(user))
                    return Json("success");

                return Json("error");
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public async Task<JsonResult> DeleteUser(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Json("error");

                }
                var result = await _userService.DeleteUser(id);
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

        [HttpPost]
        public async Task<JsonResult> UpdateUser(UserViewModel userViewModel)
        {

            try
            {
                if (userViewModel.Id <= 0)
                {
                    return Json("error");
                }

                var user = _mapper.Map<User>(userViewModel);
                if (_userService.IsExist(user).Result)
                {
                    return Json("exist");
                }

                var result = await _userService.UpdateUser(user);
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
        public async Task<IActionResult> Login(User model)
        {
            try
            {
                var result = await _userService.Login(model);
                if (result != null)
                {
                    HttpContext.Session.SetString("UserID", result.Id.ToString());
                    HttpContext.Session.SetString("UserName", result.name.Split(' ')[0]);
                    return RedirectToAction("Index" , "Home");
                }
                ViewBag.errormessage = "كلمة المرور غير صحيحة";
                return View();
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpPost]
        public async Task<JsonResult> Register(UserViewModel userViewModel)
        {
            try
            {

                var user = _mapper.Map<User>(userViewModel);

                // cheack if there are a user with the same Email
                if (_userService.IsExist(user).Result)
                {
                    return Json("exist");
                }
                await _userService.AddUser(user);
                return Json("success");


            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
