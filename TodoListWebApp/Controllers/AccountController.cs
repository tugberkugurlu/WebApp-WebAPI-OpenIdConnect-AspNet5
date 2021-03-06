﻿using Microsoft.AspNet.Http.Security;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Security.Cookies;
using Microsoft.AspNet.Security.OpenIdConnect;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoListWebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            if (Context.User == null || !Context.User.Identity.IsAuthenticated)
                return new ChallengeResult(OpenIdConnectAuthenticationDefaults.AuthenticationType, new AuthenticationProperties { RedirectUri = "/" });
            return RedirectToAction("Index", "Home");
        }

        // GET: /Account/LogOff
        [HttpGet]
        public IActionResult LogOff()
        {
            if (Context.User.Identity.IsAuthenticated)
                Context.Response.SignOut(new List<string>()
                {
                    OpenIdConnectAuthenticationDefaults.AuthenticationType,
                    CookieAuthenticationDefaults.AuthenticationType
                });
            return RedirectToAction("Index", "Home");
        }
    }
}
