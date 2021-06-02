using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolBoard.Data.DataModels
{
    public class Post
    {
        public int Id { get; set; }
        public string MyName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public IEnumerable<PostReply> Replies { get; set; }
    }
}
