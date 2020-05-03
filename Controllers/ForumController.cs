using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data.Interface;
using ForumApp.ViewModels.Forum;
using Microsoft.AspNetCore.Mvc;

namespace ForumApp.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForum _forumService;
        private readonly IPost _PostService;

        public ForumController(IForum forumservice, IPost post)
        {
            this._forumService = forumservice;
            this._PostService = post;
        }
        public IActionResult Index()
        {
            var forum = _forumService.GetAllForums();

            var forumViewModel = forum
                .Select(x => new ForumListingModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description
                });

            var model = new ForumIndexModel
            {
                ListOfForums = forumViewModel  
            };
          
            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetForumById(id);

            var posts = _PostService.GetFilteredPosts("");

            var PostListings = "";

            return View();
        }

    }
}