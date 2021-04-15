using SchoolBoard.Data.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Models.PostModels
{
    public class PostEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        
    }
}
