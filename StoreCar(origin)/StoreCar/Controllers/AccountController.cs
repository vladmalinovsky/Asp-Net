using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using StoreCar.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StoreCar.Controllers
{
    public class AccountController : Controller
    {
        ApplicationContext context = new ApplicationContext();
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
           
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName,
                    LastName = model.LastName, Address = model.Address, Phone = model.Phone};
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(user.Id, "admin");
                    var code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, Code = code },
                       protocol: Request.Url.Scheme);
                    
                    await UserManager.SendEmailAsync(user.Id, "Подтверждение электронной почты",
                               "Для завершения регистрации перейдите по ссылке:: <a href=\""
                                                               + callbackUrl + "\">завершить регистрацию</a>");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }
    
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                   if (user.EmailConfirmed == true)
                    {

                        ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut();
                        AuthenticationManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = true
                        }, claim);
                        if (String.IsNullOrEmpty(returnUrl))
                            return RedirectToAction("Index", "Home");
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Не подтвержден email.");
                    }
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult PersonalMenu()
        {
             return View("~/Views/Account/AdminMenu.cshtml");
        }

        public async Task<ActionResult> ConfirmEmail(string userId, string Code)
        {
            if (userId == null || Code == null)
            {
                return View("Error");
            }
            var result = await UserManager.ConfirmEmailAsync(userId, Code);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");
            }
            //AddErrors(result);
            return RedirectToAction("Register", "Account");
        }
    }
}
 