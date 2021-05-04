using SchoolBoard.Data;
using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.PostModels
{
    public class PostCreate
    {
        public int Id { get { using (var context = new ApplicationDbContext()) { return context.Posts.Count() + 1; } } }
        public int StudentId { get { return Student.Id; } }
        public virtual Student Student { get; set; }
        public string MyName { get; set; }

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }

    }
}
