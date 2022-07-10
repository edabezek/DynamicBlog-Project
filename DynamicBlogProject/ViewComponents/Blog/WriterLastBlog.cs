using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicBlogProject.ViewComponents.Blog
{
    public class WriterLastBlog : ViewComponent
    {
        BlogManager bm = new BlogManager(new EFArticleRepository());
        public IViewComponentResult Invoke()
        {
            var values = bm.GetArticlesListByWriter(1);
            return View(values);
        }
    }
}
