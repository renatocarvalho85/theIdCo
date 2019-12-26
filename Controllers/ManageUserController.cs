using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Pattern.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalMaggieCard.Models;

namespace PortalMaggieCard.Controllers
{
    public class ManageUserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICustomerInterface _repositoryCustomer;
        public ManageUserController(UserManager<User> userManager, SignInManager<User> signInManager, ICustomerInterface repositoryCustomer)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _repositoryCustomer = repositoryCustomer;
        }
        [TempData]
        public string StatusMessage { get; set; }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                TempData["Fail"] = "User has not fond";

            }
            var UserView = new ManageUserView
            {
                Email = user.Email,
                IsEmailConfirmrd = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                StatusMeessage = StatusMessage,
                UserName = user.UserName
                };

            return View(UserView);
        }
        public async Task<IActionResult> ChangeUserDetails()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["Fail"] = "User has not fond";
            }
            var UserView = new ManageUserView
            {
                Email = user.Email,
                IsEmailConfirmrd = user.EmailConfirmed,
                PhoneNumber = user.PhoneNumber,
                StatusMeessage = StatusMessage,
                UserName = user.UserName
            };
            return View(UserView);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangeUserDetails(ManageUserView userView)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["Fail"] = "User has not fond";
                userView.UserName = userView.Email;
                return View(userView);
            }

            if (!ModelState.IsValid)
            {
                TempData["Fail"] = "Verified the information you missed something!";
                userView.UserName = user.Email;
                return View(userView);
            }
            if (userView.Email != user.Email)
            {
                var resultEmail = await _userManager.SetEmailAsync(user, userView.Email);
                await _userManager.SetUserNameAsync(user, userView.Email);
                if (!resultEmail.Succeeded)
                {
                    TempData["Fail"] = "Something went wrong in update e-mail!";
                }

                if (resultEmail.Succeeded)
                {
                    var CustomerUser = _repositoryCustomer.GetByUserId(user.Id);

                    if (CustomerUser != null)
                    {
                        CustomerUser.CustomerEmail = userView.Email;
                        CustomerUser.CustomerName = userView.Email;

                        _repositoryCustomer.Update(CustomerUser);
                    }        
                   
                }
            }
            
            if (user.PhoneNumber != userView.PhoneNumber)
            {
                var resultPhoneNumber = await _userManager.SetPhoneNumberAsync(user, userView.PhoneNumber);
                if (!resultPhoneNumber.Succeeded)
                {
                    TempData["Fail"] = "Something went wrong in update phone number";
                }
            }
            
            TempData["Success"] = "The User has been updated";

            //var UserView = new ManageUserView
            //{
            //    Email = user.Email,
            //    IsEmailConfirmrd = user.EmailConfirmed,
            //    PhoneNumber = user.PhoneNumber,
            //    StatusMeessage = StatusMessage,
            //    UserName = user.UserName
            //};
            userView.UserName = user.Email;
            return View(userView);
        }
        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["Fail"] = "User has not fond!";
                return View();
            }
            var UserView = new ChangePasswordView();
            
            return View(UserView);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordView userView)
        {
            if (!ModelState.IsValid)
            {
                TempData["Fail"] = "Verified the information you missed something!";
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["Fail"] = "User has not fond!";
                return View();
            }
            var resultChangePassword = await _userManager.ChangePasswordAsync(user,userView.OldPassword,userView.NewPassword);
            if (!resultChangePassword.Succeeded)
            {
                TempData["Fail"] = "Password has not been changed!";
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            TempData["Success"] = "Password has been changed!";

            return View(userView);
        }
    }
}