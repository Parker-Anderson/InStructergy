using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.PostModels
{
    public class PostDetail
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public string InstructorId { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public string MyName { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
    }
}