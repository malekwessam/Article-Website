using ArticleProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticleProject.Data.Entity
{
    public class AuthorEntity : IDataHelper<Author>
    {
        private Author Author;
        private DBContext db;
        public AuthorEntity()
        {
            db = new DBContext();
        }
        public int Add(Author table)
        {
            if (db.Database.CanConnect())
            {
                db.Author.Add(table);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }

        public int Delete(int Id)
        {
            if (db.Database.CanConnect())
            {
                Author = db.Author.Find(Id);
                db.Author.Remove(Author);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }

        public Author Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Author.Where(x => x.Id == Id).FirstOrDefault();

            }
            else
                return null;
        }

        public List<Author> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Author.ToList();
            }
            else
                return null;
        }

      

        public List<Author> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Author> Search(string SearchItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Author.Where(
                x=>x.FullName.Contains(SearchItem)
              
                || x.UserName.Contains(SearchItem)
                ).ToList();
            }
            else
                return null;
        }

        public int Update(int Id, Author table)
        {
            db = new DBContext();
            if (db.Database.CanConnect())
            {
                db.Author.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }
    }
}

