using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogProject.ViewComponents.Blog
{
    public class BlogListDashboard : ViewComponent //dashboard daki Recently Published Blog kısma blog getirecek
    {
        BlogManager bm = new BlogManager(new EFArticleRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetArticlesListWithCategory();//kategori ile birlikte getirecek
            return View(values);
        }
    }
}
