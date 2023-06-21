using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            //Session.Abandon();
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public ActionResult Index(UserForLoginDto userForLoginDto)
        {
            IDataResult<User> result= _authService.Login(userForLoginDto);
            if (result.Success)
            {
                TempData["Success"] = result.Message;
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewData["Error"] = AppMessages.UserNameOrPasswordIsIncorrect;
                return View();
            }
        }
    }
}
