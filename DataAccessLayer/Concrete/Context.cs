﻿using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-D5P9P7E;Database=DynamicBlogDB;integrated security=true;");
         }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<BlogRating> BlogRatings  { get; set; }


    }
}
