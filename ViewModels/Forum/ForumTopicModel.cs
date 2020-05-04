using ForumApp.ViewModels.Posts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumApp.ViewModels.Forum
{
    public class ForumTopicModel
    {
        public IEnumerable<PostListingModel> Posts { get; set; }
        public ForumListingModel Forum { get; set; }

    }
}
