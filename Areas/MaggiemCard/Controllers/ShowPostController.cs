using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EmailSender;
using DataAccess.Model;
using DataAccess.Pattern.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortalMaggieCard.Areas.MaggiemCard.Models;
using PortalMaggieCard.Models;

namespace PortalMaggieCard.Areas.MaggiemCard.Controllers
{
    public class ShowPostController : Controller
    {
        private readonly IPostInterface _repository;
        private readonly IOrderInterface _repositoryOrder;
        private readonly ICustomerInterface _repositoryCustomer;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IProductInterface _repositoryProduct;
        private readonly IMessageService _messageService;

        public ShowPostController(IPostInterface repository, 
            IOrderInterface repositoryOrder, 
            ICustomerInterface repositoryCustomer, 
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IProductInterface repositoryProduct,
            IMessageService messageService)
        {
            _repository = repository;
            _messageService = messageService;
            _repositoryOrder = repositoryOrder;
            _repositoryCustomer = repositoryCustomer;
            _userManager = userManager;
            _signInManager = signInManager;
            _repositoryProduct = repositoryProduct;




        }
        [Area("MaggiemCard")]
        public IActionResult Index()
        {
            var post = _repository.Get();
            List<PostView> Post = new List<PostView>();
            foreach (var item in post)
            {
                Post.Add(new PostView
                {
                    Id = item.Id,
                    PostTitle = item.PostTitle,
                    PostSubTitle = item.PostSubTitle,
                    PostDate = item.PostDate,
                    PostDetails = item.PostDetails,
                    productDbId = item.productDbId,
                    PostCategoryId = item.PostCategoryId,
                    PostCategoriesView = item.PostCategories,
                    ProductsView = item.Products,

                });
            }

            return View(Post);
        }
        [Area("MaggiemCard")]
        public IActionResult ShowProductDetails(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var product = _repository.GetProduct(id);
            Product Product = new Product()
            {
                id = product.Id,
                ProductCod = product.ProductCod,
                CategoryId = product.CategoryId,
                ProductDetails = product.ProductDetails,
                ProductImagePath = product.ProductImagePath,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ProductItemOrderId = product.ProductItemOrderId,
                ItemOrderView = product.ItemOrder,
                Category = product.Category                
            };
            return View(Product);
        }
        [Area("MaggiemCard")]
        [Authorize]
        public async Task<IActionResult> BuyProduct(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var user = await _userManager.GetUserAsync(User);
            var product = _repository.GetProduct(id);
            Product Product = new Product()
            {
                id = product.Id,
                ProductCod = product.ProductCod,
                CategoryId = product.CategoryId,
                ProductDetails = product.ProductDetails,
                ProductImagePath = product.ProductImagePath,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Category = product.Category
            };
            var Customer = _repositoryCustomer.GetByUserId(user.Id);
            Order order = _repositoryCustomer.GetOrder(Customer.Id);

            if (order == null)
            {
                order = new Order
                {
                    OrderCreateDate = DateTime.Now,
                    StatusOrder = "Waiting",
                    OrderCustomerId = Customer.Id,
                    OrderPlacedDate = DateTime.Now,
                    OrderTotal = "0"
                };
                _repositoryOrder.Create(order);
            }

            var ItemExist = _repositoryOrder.GetItemOrders(order.Id);
            if (ItemExist.Any(x => x.ItemProductId == product.Id))
            {
                TempData["Alert"] = "Produst is already in your cart! ";
                return RedirectToAction("OrderDetails", new { id = order.Id });
            }
            ItemOrder itemOrder = new ItemOrder()
            {
                ItemProductId = product.Id,
                ItemProductQuantity = 1,
                OrderItemId = order.Id
            };

            itemOrder.ItemPrice = (decimal.Parse(string.Format("{0:0.00}", product.ProductPrice )) *  itemOrder.ItemProductQuantity).ToString();

            if (_repositoryOrder.CreateItemOrder(itemOrder) == true)
            {
                decimal OrderTotal = decimal.Parse(order.OrderTotal);
                decimal result = decimal.Add(OrderTotal, decimal.Parse(itemOrder.ItemPrice));
                order.OrderTotal = result.ToString();
                _repositoryOrder.Update(order);
                TempData["Success"] = "Item has been added!";
                await _messageService.SendEmail
                    (user.Email,"renato-carvalho-dos@hotmail.com", "Renato Client","renato.csantos85@gmail.com","Buy Product","Your Product has been bought");
            }
            

            var ItemOrder = _repositoryOrder.GetItemOrders(order.Id);
            OrderView Order = new OrderView()
            {
                Id = order.Id,
                OrderCreateDate = order.OrderCreateDate,
                OrderCustomerId = order.OrderCustomerId,
                StatusShip = order.StatusShip,
                OrderPlacedDate = order.OrderPlacedDate,
                StatusOrder = order.StatusOrder,
                Items = ItemOrder,
                OrderTotal = order.OrderTotal
            };
           
           
            return RedirectToAction("OrderDetails", new { id = Order.Id });
        }

        [Area("MaggiemCard")]
        [Authorize]        
        [AutoValidateAntiforgeryToken]
        [HttpGet]
       
        public IActionResult OrderDetails(int id)
        {
            if (id == 0)
            {
                TempData["Fail"] = "Information invalid!";
                return RedirectToAction("Index","ShowPost");

            }
            
            var Order = _repositoryOrder.Get(id);
            var OrderItem = _repositoryOrder.GetItemOrders(id);
            var orderView = new OrderView
                {Id = Order.Id,
                 Items = OrderItem,
                 OrderCreateDate = Order.OrderCreateDate,
                 OrderPlacedDate = Order.OrderPlacedDate,
                 OrderTotal = Order.OrderTotal,
                 StatusOrder = Order.StatusOrder,
                 StatusShip = Order.StatusShip,
                 OrderCustomerId = Order.OrderCustomerId
                };
            //foreach (var item in OrderItem)
            //{
            //    orderView.Items.Add(new ItemOrder
            //    { Id = item.Id,
            //      ItemPrice = item.ItemPrice,
            //      ItemProduct = item.ItemProduct,
            //      ItemProductId = item.ItemProductId,
            //      ItemProductQuantity = item.ItemProductQuantity,
            //      OrderItem = item.OrderItem,
            //      OrderItemId = item.OrderItemId
            //    });
            //}
            return  View(orderView);
        }


        [Area("MaggiemCard")]
        [Authorize]
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> ShowOrder()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["Fail"]= "User is not valid!";
            }
            var customer = _repositoryCustomer.GetByUserId(user.Id);

            var orders = _repositoryOrder.GetOrders(customer.Id);

            List<OrderView> Order = new List<OrderView>();
            foreach (var item in orders)
            {
                Order.Add( new OrderView
                    {
                    Id = item.Id,
                    OrderCreateDate = item.OrderCreateDate,
                    OrderCustomerId = item.OrderCustomerId,
                    StatusShip = item.StatusShip,
                    OrderPlacedDate = item.OrderPlacedDate,
                    StatusOrder = item.StatusOrder,
                    Items = item.Items,
                    OrderTotal = item.OrderTotal
                    });
                
            }
            return View(Order);
        }
        [Area("MaggiemCard")]
        [Authorize]
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeleteItem(int id)
        {
            if (id == 0)
            {
                TempData["Fail"] = "Item is not found!";
                return View();
            }
            var ItemOrder = _repositoryOrder.GetItemOrder(id);
            Order order = _repositoryOrder.Get(ItemOrder.OrderItemId);


            var OrderId = ItemOrder.OrderItemId;

            if (_repositoryOrder.DeleteItem(id) == true)
            {

                decimal OrderTotal = decimal.Parse(order.OrderTotal);
                decimal result = decimal.Subtract(OrderTotal, decimal.Parse(ItemOrder.ItemPrice) * ItemOrder.ItemProductQuantity);
                order.OrderTotal = result.ToString();
                _repositoryOrder.Update(order);

                TempData["Success"] = "Item has been deleted";
            }
            else
            {
                TempData["Fail"] = "Item has not been deleted";
            }

            return RedirectToAction("OrderDetails", new { id = OrderId });
        }
        [Area("MaggiemCard")]
        [Authorize]
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        

        public IActionResult ItemQuantity(int ItemId, int quantity)
        {
            if (ItemId == 0)
            {
                TempData["Fail"] = "Item has not been found";
                return RedirectToAction("Index");
            }
            if (quantity == 0)
            {
                TempData["Fail"] = "Information invalid";
                return RedirectToAction("Index");
            }

            var ItemOrder = _repositoryOrder.GetItemOrder(ItemId);
            var itemQuatity = ItemOrder.ItemProductQuantity;
            ItemOrder.ItemProductQuantity = quantity;
            var times = Math.Abs(itemQuatity - quantity);
           


            if (_repositoryOrder.UpdateItem(ItemOrder) == true)
            {
                var order = _repositoryOrder.Get(ItemOrder.OrderItemId);

                if (ItemOrder.ItemProductQuantity > itemQuatity)
                {
                    decimal OrderTotal = decimal.Parse(order.OrderTotal);
                    decimal result = decimal.Add(OrderTotal, decimal.Parse(ItemOrder.ItemPrice)* times);
                    order.OrderTotal = result.ToString();
                    _repositoryOrder.Update(order);

                }
                if (ItemOrder.ItemProductQuantity < itemQuatity)
                {
                    decimal OrderTotal = decimal.Parse(order.OrderTotal);
                    decimal result = decimal.Subtract(OrderTotal, decimal.Parse(ItemOrder.ItemPrice) * times);
                    order.OrderTotal = result.ToString();
                    _repositoryOrder.Update(order);
                }                

                TempData["Success"] = "Item has been updated";
            }
            else
            {
                TempData["Fail"] = "Item has not been updated";
            }

                return RedirectToAction("OrderDetails", new { id =  ItemOrder.OrderItemId});
        }
        
    }
}