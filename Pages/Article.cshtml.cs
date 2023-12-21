using ArticleProject.Core;
using ArticleProject.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace ArticlProject.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IDataHelper<Post> dataHelperForPost;
        public Post post;

        public ArticleModel(IDataHelper<Post> dataHelperForPost)

        {
            this.dataHelperForPost = dataHelperForPost;
            post = new Post();
        }



        public void OnGet()
        {
            var id = HttpContext.Request.RouteValues["id"];
            post = dataHelperForPost.Find(Convert.ToInt32(id));
        }
    }
}
