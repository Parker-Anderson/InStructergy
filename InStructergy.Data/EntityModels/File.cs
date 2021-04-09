using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InStructergy.Data.EntityModels
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FileLocation { get; set; }
        public int PostId { get; set; }
        public string OwnerId { get; set; }
    }
}
