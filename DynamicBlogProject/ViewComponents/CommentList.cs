using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicBlogProject.ViewComponents //component oluşturunca olması gereken pathler şunlar,yoksa yolu bulamama hatası verecek 
    //views/components//
    //views/shared/components/..
{
    public class CommentList : ViewComponent
    {
        
        public IViewComponentResult Invoke() //invoke : çağırmak
        {
            return View();
        }
    }
}
