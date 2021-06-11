using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.PostModels
{
    public class CreatePostModel
    {
        public string StudentName { get; set; }
        public int StudentId { get; set; }
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        

    }
}
