using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicBlogProject.Controllers
{
    public class WriterController : Controller
    {
        //[Authorize]
        //[AllowAnonymous]//geçici
        WriterManager wm = new WriterManager(new EFWriterRepository());
        public IActionResult Index() //Views/Writer/index.html e bağlı
        {
            return View();
        }
        public IActionResult WriterProfile()
        {
            return View();
        }
        
        public IActionResult WriterMail()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()//writer paneli sol kısım 
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()//writer panel alt ksım
        {
            return PartialView();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult WriterEditProfile()//writer ı getirecek hangisi ise giriş yapan Writer Profile Update

        {
            var writerValues = wm.TGetById(1);
            return View(writerValues);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult WriterEditProfile(Writer p)//writer update işlemi yaparken doğrulama ekliyoruz-- Writer Profile Update 
        {
            //WriterValidator writerValidator = new WriterValidator();
            //ValidationResult results = writerValidator.Validate(p); //using fluent validation --p den gelen değeri konrol edecek
            //if (results.IsValid)//eğer result valid ise
            //{
            wm.TUpdate(p);
            return RedirectToAction("Index", "Dashboard");
            //}
            //else 
            //{
            //    foreach (var item in results.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            //return View();

        }
    }
}
