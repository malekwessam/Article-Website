using ArticleProject.Core;
using ArticleProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ArticleProject.Code;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace ArticleProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IDataHelper<Author> dataHelper;
        private readonly IWebHostEnvironment webHost;
        private readonly IAuthorizationService authorizationService;
        private readonly Code.FileHelper fileHelper;
        private int pageItem;
        public AuthorController(IDataHelper<Author> dataHelper, IWebHostEnvironment webHost, IAuthorizationService authorizationService)
        {
            this.dataHelper = dataHelper;
            this.authorizationService = authorizationService;
            this.webHost = webHost;
            fileHelper = new Code.FileHelper(this.webHost);
            pageItem= 10;
        }
        // GET: AuthorController
        [Authorize("Admin")]
        public ActionResult Index(int? id)
        {
            if (id == 0 || id == null)
            {
                return View(dataHelper.GetAllData().Take(pageItem));
            }
            return View(dataHelper.GetAllData().Where(x => x.Id > id).Take(pageItem));
        }

        [Authorize("Admin")]
        public ActionResult Search(string SearchItem)
        {
            if (SearchItem==null)
            {
                return View(dataHelper.GetAllData());
            }
            return View("Index",dataHelper.Search(SearchItem));
        }




        // GET: AuthorController/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {
            var author=dataHelper.Find(id);
           ViewModel.AuthorView authorView=new ViewModel.AuthorView
           {
               Id = author.Id,
               Bio = author.Bio,
               FullName = author.FullName,
               Facebook = author.Facebook,
               Twitter = author.Twitter,
               Instagram = author.Instagram,
               UserId = author.UserId,
               UserName = author.UserName,
           };
            return View(authorView);
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(int id, ViewModel.AuthorView collection)
        {
            try
            {
                
                var author = new Author
                {
                    Id = collection.Id,
                    Bio = collection.Bio,
                    Facebook = collection.Facebook,
                    FullName = collection.FullName,
                    Instagram = collection.Instagram,
                    Twitter = collection.Twitter,
                    UserId = collection.UserId,
                    UserName = collection.UserName,
                    BathImage = fileHelper.UploadFile(collection.BathImage, "Images")

                };
                dataHelper.Update(id, author);

                var result = authorizationService.AuthorizeAsync(User, "Admin");
                if (result.Result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return Redirect("/AdminIndex");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        [Authorize("Admin")]
        public ActionResult Delete(int id)
        {
            var author = dataHelper.Find(id);
            ViewModel.AuthorView authorView = new ViewModel.AuthorView
            {
                Id = author.Id,
                Bio = author.Bio,
                FullName = author.FullName,
                Facebook = author.Facebook,
                Twitter = author.Twitter,
                Instagram = author.Instagram,
                UserId = author.UserId,
                UserName = author.UserName,
            };
            return View(authorView);
            
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize("Admin")]
        public ActionResult Delete(int id, Author collection)
        {
            try
            {
                dataHelper.Delete(id);
                string filebath = "~/Images/" + collection.BathImage;
                if (System.IO.File.Exists(filebath)) 
                {
                    System.IO.File.Delete(filebath);
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
