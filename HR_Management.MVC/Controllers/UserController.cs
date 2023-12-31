﻿using HR_Management.MVC.Contracts;
using HR_Management.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HR_Management.MVC.Controllers
{
	public class UserController : Controller
	{
		private IAuthenticateService _AuthenticateService;
        public UserController(IAuthenticateService AuthenticateService)
        {
			_AuthenticateService = AuthenticateService;
        }

        #region register

        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            var regsiterUser = await _AuthenticateService.Register(register);
            if (regsiterUser)
            {
                return LocalRedirect("/");
            }

            ModelState.AddModelError("", "Registerion Failed ,Please Try Again ");
            return View(register);
        }

        #endregion

        #region login

        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl)
        {
            returnUrl ??= Url.Content("~/");

            var isLoingIn = await _AuthenticateService.Authenticate(login.Email, login.Password);

            if (isLoingIn)
            {
                return LocalRedirect(returnUrl);
            }

            ModelState.AddModelError("", "Login Failed ,Please Try Again ");

            return View(login);
        }

        #endregion


        #region logout

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _AuthenticateService.Logout();
            return LocalRedirect("/Users/Login");
        }

        #endregion
    }
}
