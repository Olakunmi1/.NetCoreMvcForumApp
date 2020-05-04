using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Data.Interface;
using Forum.Data.Model;
using ForumApp.ViewModels.Forum;
using ForumApp.ViewModels.Posts;
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

            var posts = forum.Posts;

           // var posts = _PostService.GetPostsByForum(id);

            var PostListings = posts.Select(post => new PostListingModel
            {

                Id = post.Id,
                AuthorId = post.User.Id,
                AuthorRating = post.User.Rating,
                Title = post.Title,
                DatePosted = post.Created.ToString(),
                RepliesCount = post.Replies.Count(),
                Forum = BuildForumListing(post)
            });

            var model = new ForumTopicModel
            {
                Posts = PostListings,
                Forum = BuildForumListing(forum)
            };

            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;

            return BuildForumListing(forum);
        }

        private ForumListingModel BuildForumListing(Forumm forum)
        {
            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }
    }
}