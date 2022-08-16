using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogProject.Controllers
{
    public class DashboardController : Controller
    {
        BlogManager bm = new BlogManager(new EFArticleRepository());
        [AllowAnonymous]
        public IActionResult Index()//BlogListDashboard ye gider
        {

            return View();
        }
    }
}
