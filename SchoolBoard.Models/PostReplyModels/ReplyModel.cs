using System;

namespace SchoolBoard.Models.PostReplyModels
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string ImgUrl { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public int PostId { get; set; }
    }
}
