using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class UploadDocument : BaseModel
    {
        [Required]
        public long UploadTypeDetailsId{ get; set; }
        [ForeignKey("UploadTypeDetailsId")]
        public virtual UploadTypeDetail UploadTypeDetail { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public string PathUrl { get; set; }
        public string? Comment { get; set; }

    }
}
