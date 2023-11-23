using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class GradeDetail : BaseModel
    {
        public string Lavel { get; set; }
        public string X { get; set; }
        public string Y { get; set; }
        public string Z { get; set; }
    }
}
