using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class TransportationUpload : BaseModel
    {
        public long TransportationDetailsId { get; set; }
        [ForeignKey("TransportationDetailsId")]
        public virtual TransportationDetail TransportationDetail { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }

    }
}
