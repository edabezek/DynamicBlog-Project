using Microsoft.AspNetCore.Mvc;

namespace DynamicBlogProject.ViewComponents.Writer
{
    public class WriterMessageNotifications : ViewComponent
    {       
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
