using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.PostModels
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public string InstructorId { get; set; }
        public virtual ICollection<PostReply> Replies { get; set; }
        public virtual Student Student { get; set; }
        public DateTime Created { get; set; }
    }
}
