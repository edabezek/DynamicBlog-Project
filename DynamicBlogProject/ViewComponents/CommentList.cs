using DynamicBlogProject.Models;
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
            var commentValues = new List<UserComment>
            {
                new UserComment
                {
                    Id=1,
                    UserName="Ed"
                },
                new UserComment
                {
                    Id=2,
                    UserName="Mesut"
                },
                new UserComment
                {
                    Id=2,
                    UserName="Kaan"
                }
            };
            return View(commentValues);
        }
    }
}
