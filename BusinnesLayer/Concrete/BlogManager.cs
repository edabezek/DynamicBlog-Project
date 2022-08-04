using BusinnesLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IArticleDal _articleDal;

        public BlogManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public List<Article> GetArticlesListByWriter(int id)
        {
            return _articleDal.GetListAll(x => x.WriterId == id);
        }

        public List<Article> GetArticlesListWithCategory()
        {
            return _articleDal.GetListWithCategory();
        }

        public Article GetById(int id)
        {
            throw new NotImplementedException();
            //return _articleDal.GetListAll(x => x.BlogId == id);
        }
        public List<Article> GetBlogById(int id)
        {
            return _articleDal.GetListAll(x => x.BlogId == id);
        }

        public List<Article> GetList()
        {
            return _articleDal.GetListAll();
        }

        public void TAdd(Article t)
        {
            _articleDal.Insert(t);  
        }

        public void TDelete(Article t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Article t)
        {
            throw new NotImplementedException();
        }
        public List<Article> GetLastThreePost()//blog sayfasında latest post a son 3 blog getirecek
        {
            return _articleDal.GetListAll().Take(3).ToList();
        }

        public List<Article> GetListCategoryByWriterBm(int id)
        {
            return _articleDal.GetListWitCategoryByWriter(id);
        }

    }
}
