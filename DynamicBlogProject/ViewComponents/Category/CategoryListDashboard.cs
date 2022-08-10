using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogProject.ViewComponents.Category
{
    public class CategoryListDashboard : ViewComponent
    {
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IViewComponentResult Invoke()
        {
            var values = cm.GetList();
            return View(values);
        }
    }
}
