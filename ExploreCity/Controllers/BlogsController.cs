using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExploreCity.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCity.Controllers
{
    [Route("blog")]
    public class BlogsController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult post(int year,int month,string key)
        {
            var post = new Post
            {
                Title = "New post",
                Posted = DateTime.Now,
                Author = "Dhruv Kinger",
                Body = "u will like it "
            };
            return View(post);
           
        }
        [HttpGet,Route("create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost,Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid)
                return View();

            post.Author = User.Identity.Name;
            post.Posted = DateTime.Now;
            return View();
        }
    }
}