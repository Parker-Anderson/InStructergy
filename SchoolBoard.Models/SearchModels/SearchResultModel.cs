using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.SearchModels
{
    public class SearchResultModel
    {
        public IEnumerable<PostModels.PostListItem> Posts { get; set; }
        public string SearchQuery { get; set; }
        public bool EmptySearchField { get; set; }
    }
}
