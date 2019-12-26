using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Pattern.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace PortalMaggieCard.Controllers
{
    public class StripeController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ICustomerInterface _repositoryCustomer;
        public StripeController(UserManager<User> userManager, ICustomerInterface repositoryCustomer)
        {
            _userManager = userManager;
            _repositoryCustomer = repositoryCustomer;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Charge(string stripeEmail, string stripeToken,int OrderCustomerId)
        {
            var user = await _userManager.GetUserAsync(User);

            var customers = new CustomerService();
            var Customer = _repositoryCustomer.GetByUserId(user.Id);
            var order = _repositoryCustomer.GetOrder(Customer.Id);
            var charges = new ChargeService();

            var customer = customers.Create(new CustomerCreateOptions
            {
                Email = stripeEmail,
                Source = stripeToken

            });

            var charge = charges.Create(new ChargeCreateOptions
            {
                Amount = long.Parse(order.OrderTotal.Replace(".","")),
                Description = "Cards",
                Currency = "GBP",
                //CustomerId = customer.Id,
                ReceiptEmail = "renato-carvalho-dos@hotmail.com"
            });

            return View();
        }
    }
}