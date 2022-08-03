using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFArticleRepository());
        public IActionResult Index()
        {
            var values = bm.GetArticlesListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {

            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        
    }
}
