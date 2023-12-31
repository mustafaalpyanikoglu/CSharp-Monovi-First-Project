﻿using Business.Abstract;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;

namespace WebAPI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            IDataResult<List<User>> result = _userService.GetAll();
            if (result.Success)
            {
                TempData["Success"] = result.Message;
                return View(result.Data);
            }
            else
            {
                ViewData["Error"] = result.Message;
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            IDataResult<User> result = _userService.GetById(id);
            return View(result.Data);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            IDataResult<User> result = _userService.GetById(user.Id);
            result.Data.Email = user.Email;
            result.Data.FirstName = user.FirstName;
            result.Data.LastName = user.LastName;
            _userService.Update(result.Data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public PartialViewResult SearchUsers(string searchText)
        {
            IDataResult<List<User>> result = _userService.GetByName(searchText);
            return PartialView("_GridView", result.Data);
        }

         [HttpGet]
        public ActionResult GetByName(string searching)
        {
            IDataResult<List<User>> result = _userService.GetByName(searching);
            return View(result.Data);
        }

        [HttpGet]
        public ActionResult GetList()
        {
            //IDataResult<List<User>> result = _userService.GetAll();
            //return View(result.Data.ToJson());

            IDataResult<List<User>> result = _userService.GetAll();
            List<UserDto> users = new List<UserDto>();
            foreach (User user in result.Data)
            {
                users.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleId = user.RoleId,
                });
            }
            var a = Json(new { data = users }); 
            return Json(new { data = users });
        }

        public ActionResult DatatableJS()
        {
            IDataResult<List<User>> result = _userService.GetAll();
            List<UserDto> users = new List<UserDto>();
            foreach (User user in result.Data)
            {
                users.Add(new UserDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    RoleId = user.RoleId,
                });
            }
            return View(users);
        }
    }
}

