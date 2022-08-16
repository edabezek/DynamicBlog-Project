using BusinnesLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DynamicBlogProject.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EFArticleRepository());
        [AllowAnonymous]
        public IActionResult Index()//BlogListDashboard ye gider
        {
            Context context = new Context();
            ViewBag.v1 = context.Articles.Count().ToString();//Total Number of Blogs
            ViewBag.v2=context.Articles.Where(x=>x.WriterId==1).Count().ToString();//Total Number of My Blogs
            ViewBag.v3=context.Categories.Count().ToString();//Total Number of Category
            return View();
        }
    }
}
