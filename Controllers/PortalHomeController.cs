using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Context;
using DataAccess.DataProcess;
using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using PortalMaggieCard.Models;
using Microsoft.AspNetCore.Http;


namespace PortalMaggieCard.Controllers
{
    public class PortalHomeController : Controller
    {
        public IActionResult Index()
        {
            //using (Context context = new Context())
            //{
            //    foreach (var item in context.Products)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //} 


            return View();
        }

        //public IActionResult CreateProductCategory()
        //{
        //    //using (Context context = new Context())
        //    //{
        //    //    foreach (var item in context.Products)
        //    //    {
        //    //        return RedirectToAction("Index");
        //    //    }
        //    //} 


        //    return View();
        //}
        //[HttpPost]
        //public IActionResult CreateProductCategory(ProductCategory productCategory)
        //{
        //    using (Context _context = new Context())
        //    {
        //        _context.Categories.Add(productCategory);
        //        _context.SaveChanges();
        //    }
        //    //    foreach (var item in context.Products)
        //    //    {
        //    //        return RedirectToAction("Index");
        //    //    }
        //    //} 


        //    return View();
        //}


        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        ////public ActionResult CreateProduct()
        ////{
        ////    ViewData["Message"] = "Product View.";
        ////    using (Context _context = new Context())
        ////    {
        ////       var productCategory = new Product();

        ////        productCategory.Category = _context.Categories.ToList<ProductCategory>();
        ////        return View(productCategory);
        ////    }


        ////}


        //[HttpPost]
        //[AutoValidateAntiforgeryToken]
        //public ActionResult CreateProduct(Product model)
        ////{
        ////    using (Context _context = new Context())
        ////    {
        ////        if (ModelState.IsValid)
        ////        {
        ////            ProductDb product = new ProductDb();
        ////            product.ProductCod = model.ProductCod;
        ////            product.ProductName = model.ProductName;
        ////            product.ProductPrice = model.ProductPrice;
        ////            product.ProductDetails = model.ProductDetails;
        ////            product.ProductImageName = model.ProductImageName;
        ////            product.ProductImagePath = model.ProductImagePath;
        ////            product.CategoryId = model.CategoryId;




        ////            _context.Products.Add(product);
        ////            _context.SaveChanges();
        ////        }
        ////    }

        //{
        //    DataProcess.CreateProduct(model.ProductCod,
        //        model.productName,
        //        model.productPrice, 
        //        model.productDetails);

        //}
        //    return RedirectToAction("CreateProduct");
        //}

        //public ActionResult ViewProduct()
        //{
        //    ViewBag.Message = "View Product";

        //var data = DataProcess.LoadData();

        //List<Product> product = new List<Product>();

        //foreach (var row in data)
        //{
        //    product.Add(new Product
        //    {
        //        id = row.id,
        //        productId = row.productId,
        //        productName = row.productName,
        //        productPrice = row.productPrice,
        //        productDetails = row.productDetails

        //    });


        //}
        //        //return View(product);
        //         return View();
        //}
        //    public ActionResult UpdateProduct(int id)
        //    {
        //    if (id > 0)
        //    {
        //       var data =  DataProcess.GetInformation(id);
        //        Product product = new Product();


        //        foreach (var row in data)
        //        {
        //            product.id = row.id;
        //            product.productId = row.productId;
        //            product.productName = row.productName;
        //            product.productPrice = row.productPrice;
        //            product.productDetails = row.productDetails;                   
        //        }
        //        return View(product);
        //    }

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult UpdateProduct(Product model)
        //{
        //    //TODO try figure out how to load of data in the page witrout pass twice in the dataProcess.update
        //    ViewBag.Message = "Update Product";
        //    //Product modelproduct = new Product();
        //    //if (ModelState.IsValid)
        //    //{
        //    modelproduct.id = model.id;
        //    modelproduct.productId = model.productId;
        //    modelproduct.productName = model.productName;
        //    modelproduct.productPrice = model.productPrice;
        //    modelproduct.productDetails = model.productDetails;               
        //}
        // DataProcess.UpdateProduct(model.id, model.productId, model.productName, model.productPrice, model.productDetails);
        //    return View();
        //}
        //public ActionResult DetailsProduct(int id)
        //{
        ////    if (id > 0)
        ////    {
        ////        var data = DataProcess.GetInformation(id);
        //        Product product = new Product();


        //        foreach (var row in data)
        //        {
        //            product.id = row.id;
        //            product.productId = row.productId;
        //            product.productName = row.productName;
        //            product.productPrice = row.productPrice;
        //            product.productDetails = row.productDetails;
        //        }
        //        return View(product);
        //    }

        //    return View();
        //}

        //public ActionResult DeleteProduct(int id)
        //{
        //    //if (id > 0)
        //    //{
        //    //    var data = DataProcess.GetInformation(id);
        //    //    Product product = new Product();


        //    foreach (var row in data)
        //    {
        //        product.id = row.id;
        //        product.productId = row.productId;
        //        product.productName = row.productName;
        //        product.productPrice = row.productPrice;
        //        product.productDetails = row.productDetails;
        //    }
        //    return View(product);
        //}

        //            return View();
        //        }
        //        [HttpPost]
        //        public ActionResult DeleteProduct(Product model)
        //        {
        //        //    //TODO try figure out how to load of data in the page witrout pass twice in the dataProcess.update
        //        //    ViewBag.Message = "Delete Product";

        //        //    if (model.id > 0)
        //        //    {
        //        //        DataProcess.DeleteProduct(model.id, model.productId,
        //        //           model.productName,
        //        //           model.productPrice,
        //        //           model.productDetails);
        //        //    }
        //            return View();
        //        }

        //        public IActionResult Privacy()
        //        {
        //            return View();
        //        }

        //        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //        public IActionResult Error()
        //        {
        //            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        ////        }
    }
    }
