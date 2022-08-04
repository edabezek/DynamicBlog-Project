using BusinnesLayer.Concrete;
using BusinnesLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicBlogProject.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        BlogManager bm = new BlogManager(new EFArticleRepository());
        CategoryManager cm = new CategoryManager(new EFCategoryRepository());
        public IActionResult Index()
        {
            var values = bm.GetArticlesListWithCategory();
            return View(values);
        }
        public IActionResult BlogReadAll(int id)
        {

            ViewBag.i = id;
            var values = bm.GetBlogById(id);
            return View(values);
        }
        public IActionResult BlogListByWriter()//yazara göre blog listesi kısmı-tablo
        {
            var values=bm.GetListCategoryByWriterBm(1);
            return View(values);
        }
        [HttpGet]  
        public IActionResult BlogAdd()//yazarın yeni blog ekleme işleminden önce listeleme yapacağız
        {
            
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text=x.CategoryName,//ön tarafta görünecek ismi
                                                       Value=x.CategoryId.ToString()//arka taraftaki kodu 
                                                   }).ToList();
            ViewBag.cv = categoryValues;//viewbag ile categoryvalues dan gelen değerleri dropdown a taşıyacağız
            return View(); 
        }
        [HttpPost]
        public IActionResult BlogAdd(Article p)//yazarın yeni blog eklemesi
        {
            //blog validasyonunun doğruluğunun kontrolü yapacağız 
            BlogValidator bv = new BlogValidator();
            ValidationResult results = bv.Validate(p);//bv den gelen değerleri kontrol et
            if (results.IsValid)
            {
                p.BlogStatus = true;//burayı istersek başlangıçta false yapıp admine onaylatabiliriz.
                p.BlogCreateDate=DateTime.Parse(DateTime.Now.ToShortDateString());//sadece date alma işlemi
                p.WriterId = 1;
                bm.TAdd(p);
                return RedirectToAction("BlogListByWriter", "Blog");
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
        public IActionResult DeleteBlog(int id)
        {
            //silinecek değerin bulunması 
            var blogValue=bm.TGetById(id);
            //silme işlemi
            bm.TDelete(blogValue);//bizim göndermiş olduğumuz id ye karşılık gelen satırın tamamını alacak
            return RedirectToAction("BlogListByWriter");//bizi tekrar BlogListByWriter sayfasına yönlendir
        }
        [HttpGet]
        public IActionResult EditBlog(int id)//bu kısım tabloda edit tıklayınca açılan kısma gidecek
        {
            var blogValue = bm.TGetById(id);//güncelleme işleminin yapılması için,önce güncellenecek değerin çağırılması gerekiyor,burada id ye göre bul 
            //dropdown category
            List<SelectListItem> categoryValues = (from x in cm.GetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,//ön tarafta görünecek ismi
                                                       Value = x.CategoryId.ToString()//arka taraftaki kodu 
                                                   }).ToList();
            ViewBag.cv = categoryValues;//viewbag ile categoryvalues dan gelen değerleri dropdown a taşıyacağız
            
            return View(blogValue);//ve değeri döndür-view a bas diyoruz
        }
        [HttpPost]
        public IActionResult EditBlog(Article p)//seçtiğimiz edit sayfasındaki yeşil edit butonuna tıkladığımızda sadece bir değer değiştirilip kaydedilirse,atamadığımız sütunlara ya null yada default değer atar.bunun için date ve blogstatus ü burada belirtmek zorundayız.
        {
            p.WriterId = 1;
            p.BlogCreateDate =DateTime.Parse( DateTime.Now.ToShortDateString());
            p.BlogStatus = true;
            bm.TUpdate(p);//parametreden gelen değeri güncelle
            return RedirectToAction("BlogListByWriter");
        }
    }
}
