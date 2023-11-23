using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class AccomodationUpload : BaseModel
    {
        public long AccomodationDetailsId { get; set; }
        [ForeignKey("AccomodationDetailsId")]
        public virtual AccomodationDetail AccomodationDetail { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

    }
}
