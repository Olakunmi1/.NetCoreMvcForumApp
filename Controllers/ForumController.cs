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

        public ForumController(IForum forumservice)
        {
            this._forumService = forumservice;
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
    }
}