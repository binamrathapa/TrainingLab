using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Training3Lab.Models;

namespace Training3Lab.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginViewModel login = new UserLoginViewModel();
            return View(login);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel userLogin)
        {
           
            ApplicationUser user = new ApplicationUser { UserName= userLogin.UserName,Password= userLogin.Password};


            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            
            var t = this.User.Identity;
            return RedirectToAction("Index","Student");
            //return View(userLogin);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}