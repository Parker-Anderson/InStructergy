using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Models.Student
{
    public class StudentDetailViewModel
    {
        public StudentsListItem Student { get; set; }
        public IEnumerable<PostModels.PostListItem> Posts { get; set; }
    }
}
