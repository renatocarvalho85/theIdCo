using System.Collections.Generic;
using DataAccess.Model;
using DataAccess.Pattern.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalMaggieCard.Models;

using PortalMaggieCard.FileManager;

namespace PortalMaggieCard.Controllers
{
    public class ProductController : Controller
    {
        private IProductInterface _repository;
        private IFileInterface _fileRepository;
        //private string _ImagePath;
        public ProductController(IProductInterface repository, IFileInterface fileRepository)
        {
            _repository = repository;
            _fileRepository = fileRepository;
            //_ImagePath = "wwwroot/images/ImageProduct";
        }
        public ActionResult Index()
        {
            var Product = _repository.GetProductCategory();
            List<Product> product = new List<Product>();

            foreach (var item in Product)
            {
                product.Add(new Product
                {
                    id = item.Id,
                    CategoryId = item.CategoryId,
                    ProductCod = item.ProductCod,
                    
                    ProductDetails = item.ProductDetails,
                    ProductName = item.ProductName,
                    
                    ProductPrice = item.ProductPrice,
                    Category = item.Category
                }) ;

            }

            return View(product);
        }

        public IActionResult CreateProduct()
        {
            
            var ProductCategory = _repository.GetProductCategories();
            var productCategory = new Product{
                //ProductDetails = "",
                //ProductPrice ="",
                //ProductName = "",
                //ProductCod = "",
                CategoryId = 0,
                Categories = new SelectList(ProductCategory, "Id", "ProductCategoryName")};
            

            return View(productCategory);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateProduct(Product product)
        {

            var Product = new ProductDb()
            { ProductCod = product.ProductCod,
              CategoryId = product.CategoryId,
              ProductDetails = product.ProductDetails,
              //ProductImageName = product.ProductImageName,
              ProductImagePath = _fileRepository.SaveImage(product.ProductImageName),
              ProductName = product.ProductName,
              ProductPrice = product.ProductPrice};

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Message", "Information invalid.");
                return RedirectToAction("CreateProduct");
            }
            
            if(_repository.Create(Product) == true )

               TempData["Success"] = "New Product has been created with Success";

            return RedirectToAction("Index");
        }
        public IActionResult CreateProductCategory()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreateProductCategory(ProductCategory category)
        {
            if (ModelState.IsValid)
            {
                if (_repository.CreateCategory(category) == true)
                    ViewData["Success"] = "Category has been created with Success";
            }
            
            return View();
        }
        public IActionResult UpdateProduct(int id)
        {

            var product = _repository.Get(id);
            var productCategory = _repository.GetProductCategories();
            Product Product = new Product()
            {
                id = product.Id,
                ProductCod = product.ProductCod,
                CategoryId = product.CategoryId,
                ProductDetails = product.ProductDetails,
                //ProductImageName = null,
                ProductImagePath = product.ProductImagePath,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Categories = new SelectList(productCategory,"Id","ProductCategoryName")
            };
            

            return View(Product);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.ProductImageName != null)
            {
                _fileRepository.DeleteImage(product.ProductImagePath);
                product.ProductImagePath = _fileRepository.SaveImage(product.ProductImageName);                
            }
            ProductDb Product = new ProductDb()
            {
                Id = product.id,
                ProductCod = product.ProductCod,
                CategoryId = product.CategoryId,
                ProductDetails = product.ProductDetails,
                //ProductImageName = await _fileRepository.SaveImage(product.ProductImageName),
                ProductImagePath = product.ProductImagePath,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice
            };
            if (ModelState.IsValid)
            {
                _repository.Update(Product);
                TempData["Success"] = "Product has been edited with Success";
                return RedirectToAction("UpdateProduct", product.id);

            }
            return View(product);
        }
        public IActionResult ProductDetails(int id)
        {
           var product = _repository.GetProductCategory(id);
            Product Product = new Product()
            {
                id = product.Id,
                ProductCod = product.ProductCod,
                CategoryId = product.CategoryId,
                ProductDetails = product.ProductDetails,
                //ProductImageName = await _fileRepository.SaveImage(product.ProductImageName,_ImagePath), 
                ProductImagePath = product.ProductImagePath,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Category = product.Category
            };
            return View(Product);
        }


        public IActionResult DeleteProduct(int id)
        {
            var product = _repository.Get(id);
            var Product = new Product()
            {
                ProductCod = product.ProductCod,
                CategoryId = product.CategoryId,
                ProductDetails = product.ProductDetails,
                //ProductImageName = product.ProductImageName,
                ProductImagePath = product.ProductImagePath,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice
            };

            return View(Product);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        [ActionName("DeleteProduct")]
        public IActionResult ConfirmDeleteProduct(int id)
        {
            var product = _repository.Get(id);
            _fileRepository.DeleteImage(product.ProductImagePath);
            _repository.Delete(id);
            TempData["Success"] = "Product has been deleted with Success";
            return RedirectToAction("Index");
        }
    }
}