using SchoolBoard.Data.DataModels;
using SchoolBoard.Models.PostReplyModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.PostModels
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImgUrl { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public IEnumerable<ReplyModel> Replies { get; set; }
    }
}
