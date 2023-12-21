using ArticleProject.Core;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ArticleProject.Data.Entity
{
    public class CategoryEntity : IDataHelper<Category>
    {
        private Category category;
        private DBContext db;
        public CategoryEntity() 
        {
            db=new DBContext();
        }
        public int Add(Category table)
        {
            if (db.Database.CanConnect())
            {
                db.Category.Add(table);
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
                category = db.Category.Find(Id);
                db.Category.Remove(category);
                db.SaveChanges();
                return 1;
            }
            else 
                return 0; 
        }

        public Category Find(int Id)
        {
            if (db.Database.CanConnect())
            {
                return db .Category.Where(x=>x.id==Id).FirstOrDefault();
               
            }
           else
                return null;
        }

        public List<Category> GetAllData()
        {
            if (db.Database.CanConnect())
            {
                return db.Category.ToList();
            }
            else
                return null;
        }

        public List<Category> GetDataByUser(string UserId)
        {
            throw new NotImplementedException();
        }

        public List<Category> Search(string SearchItem)
        {
            if (db.Database.CanConnect())
            {
                return db.Category.Where(x => x.Name.Contains(SearchItem)||x.id.ToString().Contains(SearchItem)).ToList();
            }
            else
                return null;
        }

        public int Update(int Id, Category table)
        {
            db=new DBContext();
            if (db.Database.CanConnect())
            {
                db.Category.Update(table);
                db.SaveChanges();
                return 1;
            }
            else
                return 0;
        }
    }
}
