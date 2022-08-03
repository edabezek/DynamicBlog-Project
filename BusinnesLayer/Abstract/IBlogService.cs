using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Abstract
{
    public interface IBlogService : IGenericService<Article>
    {       
        List<Article> GetArticlesListWithCategory();//data access de oluşturduğumuz liste methodu çağırıyoruz.kategori ile beraber listeyi getir diyoruz.
        List<Article> GetArticlesListByWriter(int id);//yazar ile blogları getir ,Other Writings By The Author kısmı için 
    }
}
