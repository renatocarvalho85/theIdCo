using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Pattern.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalMaggieCard.Areas.MaggiemCard.Controllers;
using PortalMaggieCard.Models;

namespace PortalMaggieCard.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICustomerInterface _repositoryCustomer;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICustomerInterface repositoryCustomer)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _repositoryCustomer = repositoryCustomer;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserView model, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.UserEmail, Email = model.UserEmail};

                var result = await _userManager.CreateAsync(user, model.UserPassword);

                if (result.Succeeded)
                {
                    var CustomerUser = new Customer {CustomerName = model.UserEmail,CustomerEmail = model.UserEmail, UserId = user.Id };
                    _repositoryCustomer.Create(CustomerUser);

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "MaggiemCard/ShowPost");
                    }                   
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("Errors", item.Description);
                }
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginView model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            

            if (ModelState.IsValid)
            {
                
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Rememberme, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "MaggiemCard/ShowPost");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Information invalid");

                }
            }
           
            return View(model);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index","MaggiemCard/ShowPost");
        }
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "MaggiemCard/ShowPost");
            }
        }
    }
}