using ArticleProject.Core;
using ArticleProject.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ArticleProject.Controllers
{
    [Authorize("Admin")]
    public class CategoryController : Controller
    {
        private readonly IDataHelper<Category> dataHelper;
        private int pageItem;
        public CategoryController(IDataHelper<Category> dataHelper)
        {
            this.dataHelper = dataHelper;
            pageItem = 10;
        }
        // GET: CategoryController
        public ActionResult Index(int? id)
        {
            if (id == 0||id == null) 
            {
                return View(dataHelper.GetAllData().Take(pageItem));
            }
           return View(dataHelper.GetAllData().Where(x=>x.id>id).Take(pageItem));
        }

        public ActionResult Search(string SearchItem)
        {
            if (SearchItem == null)
            {
                return View("Index",dataHelper.GetAllData());
            }
            return View("Index", dataHelper.Search(SearchItem));
        }


        // GET: CategoryController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View(dataHelper.Find(id));
        //}

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
               var result= dataHelper.Add(category);
                if (result==1) {

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();


            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            
                return View(dataHelper.Find(id));

        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                var result = dataHelper.Update(id, category);
                if (result == 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {

                var result = dataHelper.Delete(id);
                if (result == 1)
                {

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();

            }
            catch
            {
                return View();
            }
        }
    }
}
