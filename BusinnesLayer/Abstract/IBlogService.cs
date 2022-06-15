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
        Category GetById(int id);

        List<Article> GetArticlesListWithCategory();
    }
}
