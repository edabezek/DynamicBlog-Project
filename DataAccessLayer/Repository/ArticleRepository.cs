using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ArticleRepository : IArticleDal
    {
        public void AddArticle(Article article)
        {
            using var c = new Context();
            c.Add(article);
            c.SaveChanges();
        }

        public void DeleteArticle(Article article)
        {
            using var c = new Context();
            c.Remove(article);
            c.SaveChanges();
        }

        public Article GetById(int id)
        {
            using var c = new Context();
            return c.Articles.Find(id);
        }

        public List<Article> ListAllArticle()
        {
            using var c = new Context();
            return c.Articles.ToList();
        }

        public void UpdateArticle(Article article)
        {
            using var c = new Context();
            c.Update(article);
            c.SaveChanges();
        }
    }
}
