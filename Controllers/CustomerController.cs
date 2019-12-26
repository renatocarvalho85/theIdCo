using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Pattern.Interface;
using Microsoft.AspNetCore.Mvc;
using PortalMaggieCard.Models;
using DataAccess.Model;

namespace PortalMaggieCard.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerInterface _repository;
        public CustomerController(ICustomerInterface repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
           var customer = _repository.Get();
            
            List<CustomerView> Customer = new List<CustomerView>();
            foreach (var item in customer)
            {
                Customer.Add(new CustomerView
                {
                    Id = item.Id,
                    CustomerAddress = item.CustomerAddress,
                    CustomerEmail = item.CustomerEmail,
                    CustomerName = item.CustomerName,
                    CustomerPassword = item.CustomerPassword,
                    CustomerPhone = item.CustomerPhone,
                    
                });
            }

            return View(Customer);
        }
        public IActionResult CreateCustomer()
        {
            return View();
        }
        [HttpPost]

        public IActionResult CreateCustomer(CustomerView customer)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var Customer = new Customer
            {
                CustomerAddress = customer.CustomerAddress,
                CustomerEmail = customer.CustomerEmail,
                CustomerName = customer.CustomerName,
                CustomerPassword = customer.CustomerPassword,
                CustomerPhone = customer.CustomerPhone
            };
            if (_repository.Create(Customer) == true)
            {
                TempData["Success"] = "The customer has been created!";
            }else
                TempData["Fail"] = "The customer hasn't been created!";

            return RedirectToAction("CreateCustomer");
        }
        public IActionResult UpdateCustomer(int id)
        {
            var customer = _repository.Get(id);
            var Customer = new CustomerView
            {
                Id = customer.Id,
                CustomerAddress = customer.CustomerAddress,
                CustomerEmail = customer.CustomerEmail,
                CustomerName = customer.CustomerName,
                CustomerPassword = customer.CustomerPassword,
                CustomerPhone = customer.CustomerPhone
            };

            return View(Customer);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateCustomer(CustomerView customer)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var Customer = new Customer
            {
                Id = customer.Id,
                CustomerAddress = customer.CustomerAddress,
                CustomerEmail = customer.CustomerEmail,
                CustomerName = customer.CustomerName,
                CustomerPassword = customer.CustomerPassword,
                CustomerPhone = customer.CustomerPhone
            };
            if (_repository.Update(Customer) == true)
            {

                ViewData["Success"] = "The customer has been edited!";
            }
            else
                ViewData["Fail"] = "The customer hasn't been edited!";

            return View(customer);
        }
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _repository.Get(id);
            var Customer = new CustomerView
            {
                Id = customer.Id,
                CustomerAddress = customer.CustomerAddress,
                CustomerEmail = customer.CustomerEmail,
                CustomerName = customer.CustomerName,
                CustomerPassword = customer.CustomerPassword,
                CustomerPhone = customer.CustomerPhone
            };

            return View(Customer);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteCustomer(CustomerView customer)
        {
            if (customer.Id == 0)
            {
                return NotFound();
            }
            if (_repository.Delete(customer.Id) == true)
            {
                TempData["Success"] = "The customer has been deleted!";
            }
            else
                TempData["Fail"] = "The customer hasn't been deleted!";

            return RedirectToAction("Index");

        }
    }
}