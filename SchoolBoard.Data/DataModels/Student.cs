using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Data.DataModels
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double GPA { get; set; }
        public bool SatisfactoryPerformance { get; set; }
        public string ImgUrl { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        

    }
}