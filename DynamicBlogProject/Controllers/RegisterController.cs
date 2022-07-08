using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicBlogProject.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EFWriterRepository());

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            //yazar validasyonunun doğruluğunun kontrolü yapacağız 
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);//vriter validator içindeki değerleri kontrol edecek,parametreden gelen değerler ile
            if (results.IsValid)//eger sonuclar geçerliyse,işlemleri yap
            {
                p.WriterStatus = true;
                p.WriterAbout = "Deneme test";

                wm.AddWriter(p);
                return RedirectToAction("Index", "Blog");
            }
            else//diyelim ismi 55 karakter girdik 
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//model durumuna bi tane hata ekle, hatayı veren property ismi,hatanın kendisi

                }
            }
            return View();//işlem geçersizse bir view dönecek



            
        }
    }
}
