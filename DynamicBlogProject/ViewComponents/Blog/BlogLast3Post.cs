using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogProject.ViewComponents.Blog
{
    public class BlogLast3Post : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFArticleRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetLastThreePost();
            return View(values);
        }
    }
}
