using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogProject.ViewComponents.Writer
{
    public class WriterNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
