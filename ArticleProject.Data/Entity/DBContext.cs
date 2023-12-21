using ArticleProject.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Data.Entity
{
    public class DBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=True;Initial Catalog=ArticleAd;Data Source=DESKTOP-NAR20KV\\SQLEXPRESS");
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Post> Post { get; set; }
    }
}
