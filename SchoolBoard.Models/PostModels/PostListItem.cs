using SchoolBoard.Data.DataModels;
using SchoolBoard.Models.Student;
using System;

namespace SchoolBoard.Models.PostModels
{
    public class PostListItem
    {
        public int Id { get; set; }
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public StudentsListItem Student { get; set; }

        public int RepliesCount { get; set; }



    }
}
