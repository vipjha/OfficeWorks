using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class UploadTypeDetail : BaseModel
    {
        [Required]
        public long EmpTourPlanId { get; set; }
        [ForeignKey("EmpTourPlanId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        public long UploadTypeId { get; set; }
        [ForeignKey("UploadTypeId")]
        public virtual UploadDocType UploadDocType { get; set; }
        public double Amount { get; set; }
    }
}
