using SchoolBoard.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolBoard.Data.DataModels
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public virtual Post Post { get; set; }
    }
}