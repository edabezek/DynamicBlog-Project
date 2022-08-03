using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DynamicBlogProject.Controllers
{
    public class LoginController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Index(Writer p)
        {
            Context c = new Context();
            var dataValue = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            if (dataValue != null)
            {
                var claims = new List<Claim>//talep oluşturduk bunlar liste halinde olacak
                {
                    new Claim(ClaimTypes.Name,p.WriterMail)
                };
                var userIdentity=new ClaimsIdentity(claims,"a");
                ClaimsPrincipal principal =new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Writer");
            }
            else
            {
                return View();
            }

        }
        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult Index(Writer p)
        //{
        //    Context c = new Context();
        //    var dataValue = c.Writers.FirstOrDefault(x=>x.WriterMail==p.WriterMail && x.WriterPassword==p.WriterPassword);
        //    if (dataValue!=null)//kullanıcının girdiği değerler doğrulanırsa 
        //    {
        //        HttpContext.Session.SetString("username",p.WriterMail);//kullanıcı bilgilerini tutmak için server tarafında işlem yapar 
        //        return RedirectToAction("Index", "Writer");
        //    }
        //    else
        //    {
        //        return View();
        //    }

        //}

    }
}
