using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IBlogService
    {
        void BlogAdd(Article article);
        void BlogDelete(Article article);
        void BlogUpdate(Article article);
        List<Article> GetList();
        Article GetById(int id);//category idi değiştirdim

        List<Article> GetArticlesListWithCategory();//data access de oluşturduğumuz liste methodu çağırıyoruz.kategori ile beraber listeyi getir diyoruz.

        
    }
}
