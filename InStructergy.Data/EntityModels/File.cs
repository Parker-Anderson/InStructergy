using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolBoard.Data.EntityModels
{
    public class File
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileLocation { get; set; }
        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}
