using SchoolBoard.Data;
using SchoolBoard.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models
{
    public class PostListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string InstructorId { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
