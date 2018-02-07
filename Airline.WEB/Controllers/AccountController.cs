using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Airline.BLL.DTO;
using Airline.BLL.Infrastructure;
using Airline.BLL.Interfaces;
using Airline.WEB.Models;
using AutoMapper;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Airline.WEB.Controllers
{
    public class AccountController : Controller
    {
        private IUserService UserService => HttpContext.GetOwinContext().GetUserManager<IUserService>();

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();

            if (ModelState.IsValid)
            {
                var userDto = Mapper.Map<LoginModel, UserDto>(model);
                var claim = await UserService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Wrong input or password");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("List", "Flight");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("List", "Worker");

        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                var userDto = Mapper.Map<RegisterModel, UserDto>(model);
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succeded)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new List<UserDto>{new UserDto
            {
                Email = "ivan_dispatcher@gmail.com",
                Password = "ad46D_ewr3",
                Name = "Ivan_Pavlov",
                Role = "Dispatcher",
            }, new UserDto()
                {
                    Email = "daria_admin@gmail.com",
                    Password = "ad46D_ewr3",
                    Name = "Daria_Reva",
                    Role = "Admin",
                }}, new List<string> { "Dispatcher", "Admin" });
        }
    }
}