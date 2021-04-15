using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Data.EntityModels
{
    public class PostReply
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Instructor))]
        public string InstructorId { get; set; }
        public virtual ApplicationUser Instructor { get; set; }
        public string Label { get; set; }
        public string Body { get; set; }
    }
}
