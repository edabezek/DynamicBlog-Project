using BusinnesLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DynamicBlogProject.ViewComponents.Writer
{
    
    public class WriterAboutOnDashboard : ViewComponent //dashboard daki yazar hakkında olan kısım 
    {
        WriterManager writerManager = new WriterManager(new EFWriterRepository());
        public IViewComponentResult Invoke()
        {
            var values = writerManager.GetWriterById(1);
            return View(values);
        }
    }
}
