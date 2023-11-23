using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class UploadDocType
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? IsBillable { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
