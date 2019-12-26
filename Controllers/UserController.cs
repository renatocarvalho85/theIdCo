using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.Pattern;
using DataAccess.Pattern.Interface;
using DataAccess.Model;
using PortalMaggieCard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PortalMaggieCard.Controllers
{
    public class UserController : Controller
    {
        private IUserInterface _repository;
        public UserController(IUserInterface repository)
        {
            _repository = repository;
        }
        //public IActionResult Index()
        //{
        //    var userAndRole = _repository.GetUserAndRole();
        //    var UserAndRole = new List<UserView>();
        //    foreach (var item in userAndRole)
        //    {
        //        UserAndRole.Add(new UserView
        //        {
        //            Id = item.Id,
        //            UserName = item.UserName,
        //            UserFullName = item.UserFullName,
        //            UserEmail = item.UserEmail,
        //            UserRole = item.UserRole

        //        });
        //    }
        //    return View(UserAndRole);
        //}
        ////TODO Create way to delete UserRole
        //public IActionResult CreateUserRole()
        //{

        //    return View();
        //}
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult CreateUserRole(UserRoleView userRole)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return NotFound();
        //    }
        //    var UserRole = new UserRole
        //    {
        //        UserRoleName = userRole.UserRoleName
        //    };

        //    if (_repository.CreateUserRole(UserRole) == true)
        //    {
        //        ViewData["Success"] = "User Role has been created with Success";
        //    }
        //    else
        //        ViewData["Fail"] = "User Role hasn't been created ";

        //    return View();
        //}
        ////TODO Create way to valided the user email Address
        //public IActionResult CreateUser()
        //{
        //    var userRole = _repository.GetUserRoles();

        //    UserView UserRole = new UserView
        //    {
        //        UserRoles = new SelectList(userRole, "Id", "UserRoleName")
        //    };

        //    return View(UserRole);
        //}
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult CreateUser(UserView user)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return NotFound();
        //    }
        //    var User = new User
        //    {
        //        UserName = user.UserName,
        //        UserFullName = user.UserFullName,
        //        UserEmail = user.UserEmail,
        //        UserPassword = user.UserPassword,
        //        UserRoleId = user.UserRoleId
        //    };
        //    if (_repository.Create(User) == true)
        //    {
        //        TempData["Success"] = "User has been created!";
        //    }
        //    else
        //        TempData["Fail"] = "User hasn't been created!";

        //    return RedirectToAction("CreateUser");
        //}
        //public IActionResult UpdateUser(int id)
        //{
        //    var user = _repository.GetUserRoles(id);
        //    var userRole = _repository.GetUserRoles();
        //    var User = new UserView
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName,
        //        UserFullName = user.UserFullName,
        //        UserEmail = user.UserEmail,
        //        UserRole = user.UserRole,
        //        UserRoleId = user.UserRoleId,
        //        UserRoles = new SelectList(userRole, "Id", "UserRoleName")
        //    };


        //    return View(User);
        //}
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public IActionResult UpdateUser(UserView user)
        //{
        //    var User = new User
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName,
        //        UserFullName = user.UserFullName,
        //        UserEmail = user.UserEmail,
        //        UserRole = user.UserRole,
        //        UserRoleId = user.UserRoleId                
        //    };
        //    if (!ModelState.IsValid)
        //    {
        //        return NotFound();
        //    }
        //    if (_repository.Update(User) == true)
        //    {
        //        ViewData["Success"] = "User has been edited!";
        //    }
        //    else
        //        ViewData["Fail"] = "User hasn't been edited!";

        //    return View();
        //}
        //public IActionResult DeleteUser(int id)
        //{
        //    var user = _repository.Get(id);
        //    var User = new UserView
        //    {
        //        Id = user.Id,
        //        UserName = user.UserName,
        //        UserFullName = user.UserFullName,
        //        UserEmail = user.UserEmail,
        //        UserRole = user.UserRole,
        //        UserRoleId = user.UserRoleId,
        //        //UserRoles = new SelectList(userRole, "Id", "UserRoleName")
        //    };

        //    return View(User);
        //}
        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //[ActionName("DeleteUser")]
        //public IActionResult ConfirmDeleteUser(User user)
        //{
        //    //var user = _repository.Get(id);
        //    //_fileRepository.DeleteImage(product.ProductImagePath);
        //    _repository.Delete(user.Id);
        //    TempData["Success"] = "User has been deleted with Success";
        //    return RedirectToAction("Index");
        //}
    }
}