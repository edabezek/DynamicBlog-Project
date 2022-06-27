using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetListWithCategory();//kategoriyle beraber listeyi getir,sadece bloglara özel olduğu için burada tanımlıyoruz 

    }
}
