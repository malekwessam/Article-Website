using ArticleProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArticleProject.Data.Entity
{
    public class PostEntity : IDataHelper<Post>
    {
        private Post _table;
        private DBContext db;
        public PostEntity()
        {
            db = new DBContext();
        }
        public int Add(Post table)
        {
            if (db.Database.CanConnect())
            {

                db.Post.Add(table);
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
                _table = Find(Id);
                db.Post.Remove(_table);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }

        public Post Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db.Post.Where(x => x.Id == Id).First();
            }
            else
            {
                return null;
            }
        }

        public List<Post> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Post.ToList();
            }
            else
                return null;
        }

        public List<Post> GetDataByUser(string UserId)
        {
            if (db.Database.CanConnect())
            {
                return db.Post.Where(x => x.UserId== UserId).ToList();
            }
            else
                return null;
        }

        public List<Post> Search(string SearchItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Post.Where(
                x => x.Id.ToString().Contains(SearchItem)
                || x.PostTitle.Contains(SearchItem)
                || x.PostDescription.Contains(SearchItem)
                || x.UserId.Contains(SearchItem)
                || x.UserName.Contains(SearchItem)
                || x.FullName.Contains(SearchItem)
                || x.AuthorId.ToString().Contains(SearchItem)
                || x.CategoryId.ToString().Contains(SearchItem)
                || x.PostCategory.Contains(SearchItem)
                
                || x.AvailableSince.ToString().Contains(SearchItem))
                .ToList();
            }
            else
                return null;
        }

        public int Update(int Id, Post table)
        {
            if (db.Database.CanConnect())
            {

                db.Post.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }
    }
}
