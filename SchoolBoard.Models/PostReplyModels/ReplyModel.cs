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
        public string PostTitle { get; set; }
        public string PostBody { get; set; }

        public string StudentName { get; set; }
        public string StudentImgUrl { get; set; }
        public int StudentId { get; set; }
    }
}
