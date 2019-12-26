using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.Pattern.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortalMaggieCard.Models;

namespace PortalMaggieCard.Controllers
{
    public class PostController : Controller
    {
        private IPostInterface _repository;
        public PostController(IPostInterface repository)
        {
            _repository = repository;
        }
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
                    ProductsView = item.Products
                });
            }
            
            return View(Post);
        }
        public IActionResult CreatePostCategory()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePostCategory(PostCategoryView postCategory)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var PostCategory = new PostCategory
            {PostCategoryName = postCategory.PostCategoryName
            };
            if (_repository.CreatePostCategory(PostCategory) == true)
            {
                TempData["Success"] = "The post category has been created!";
            }else
                TempData["Fail"] = "The post category hasn't been created!";

            return RedirectToAction("CreatePostCategory");
        }
        public IActionResult CreatePost()
        {
            var product = _repository.GetProducts();
            var postCategory = _repository.GetPostCategories();
            var Post = new PostView
            {
                OptionPoducts = new SelectList(product,"Id","ProductName"),
                OptionPostCategories = new SelectList(postCategory,"Id","PostCategoryName")
            };
            return View(Post);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult CreatePost(PostView post)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var Post = new Post
            {
                productDbId = post.productDbId,
                PostCategoryId = post.PostCategoryId,
                PostDate = DateTime.Now,
                PostDetails = post.PostDetails,
                PostSubTitle = post.PostSubTitle,
                PostTitle = post.PostTitle
            };
            if (_repository.Create(Post) == true)
            {
                TempData["Success"] = "The post has been created!";
            }else
                TempData["Fail"] = "The post hasn't been created!";

            return RedirectToAction("CreatePost");
        }
        public IActionResult UpdatePost(int id)
        {
            var post =_repository.Get(id);
            var product = _repository.GetProducts();
            var postCategory = _repository.GetPostCategories();
            var Post = new PostView
            {
                Id = post.Id,
                PostCategoryId = post.PostCategoryId,
                PostTitle = post.PostTitle,
                PostSubTitle = post.PostSubTitle,
                productDbId = post.productDbId,
                PostCategoriesView = post.PostCategories,
                ProductsView = post.Products,
                PostDate = post.PostDate,
                PostDetails = post.PostDetails,
                OptionPoducts = new SelectList(product, "Id","ProductName"),
                OptionPostCategories = new SelectList(postCategory,"Id","PostCategoryName")               
            };


            return View(Post);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult UpdatePost(PostView post)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var Post = new Post
            {
                Id = post.Id,
                PostCategoryId = post.PostCategoryId,
                PostTitle = post.PostTitle,
                PostSubTitle = post.PostSubTitle,
                productDbId = post.productDbId,
                PostDate = DateTime.Now,
                PostDetails = post.PostDetails
            };
            if (_repository.Update(Post) == true)
            {
                TempData["Success"] = "The post has been edited!";
            }
            else
                TempData["Fail"] = "The post hasn't been edited!";

            return RedirectToAction("UpdatePost");
        }
        public IActionResult DeletePost(int id)
        {
            var post = _repository.Get(id);
            var Post = new PostView
            {
                Id = post.Id,
                PostTitle = post.PostTitle,
                PostSubTitle = post.PostSubTitle,
                productDbId = post.productDbId,
                PostCategoryId = post.PostCategoryId,
                PostDate = post.PostDate,
                PostDetails = post.PostDetails,
                ProductsView = post.Products,
                PostCategoriesView = post.PostCategories
            };

            return View(Post);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult DeletePost(PostView post)
        {
            if (_repository.Delete(post.Id)== true)
            {
                TempData["Success"] = "The post has been deleted!";
            }
            else
                TempData["Fail"] = "The post hasn't been deleted!";

            return RedirectToAction("Index");
        }
    }
}