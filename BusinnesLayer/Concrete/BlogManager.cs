﻿using BusinnesLayer.Abstract;
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

        public void BlogAdd(Article article)
        {
            throw new NotImplementedException();
        }

        public void BlogDelete(Article article)
        {
            throw new NotImplementedException();
        }

        public void BlogUpdate(Article article)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetArticlesListWithCategory()
        {
            return _articleDal.GetListWithCategory();
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetList()
        {
            return _articleDal.GetListAll();
        }
    }
}
