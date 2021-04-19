using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Data.DomainModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual IEnumerable<PostReply> Replies { get; set; }
        [ForeignKey(nameof(Instructor))]
        public string InstructorId { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public DateTime Created { get; set; }
    }
}

