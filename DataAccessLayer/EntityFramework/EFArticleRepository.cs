using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EFArticleRepository : GenericRepository<Article>, IArticleDal
    {
        public List<Article> GetListWitCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Articles.Include(x => x.Category).Where(x=>x.WriterId==id).ToList();
            }
        }

        public List<Article> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Articles.Include(x => x.Category).ToList();//kategori tablosuna ait değerleri liste olarak getirecek.
            }
                
        }
    }
}
