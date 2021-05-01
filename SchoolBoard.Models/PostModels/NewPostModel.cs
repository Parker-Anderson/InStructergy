using SchoolBoard.Data;
using SchoolBoard.Data.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.PostModels
{
    public class NewPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public virtual Student Student { get; set; }
        public int StudentId { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public string StudentName { get; set; }
        public string InstructorName { get; set; }
        public DateTime Created { get; set; }
        public string InstructorId { get; set; }
    }
}