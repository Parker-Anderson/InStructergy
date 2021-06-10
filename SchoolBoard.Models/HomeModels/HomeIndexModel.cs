using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.HomeModels
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostModels.PostListItem> RecentPosts { get; set; }
    }
}
