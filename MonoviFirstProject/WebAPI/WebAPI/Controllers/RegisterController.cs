using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserForRegisterDto userForRegisterDto)
        {
            IDataResult<User> result =_authService.Register(userForRegisterDto, userForRegisterDto.Password);
            if (result.Success)
            {
                TempData["Success"] = result.Message;
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["Error"] = result.Message;
                return View();
            }
        }
    }
}
