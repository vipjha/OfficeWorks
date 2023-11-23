using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class DADetail : BaseModel
    {
        [Required]
        public long EmpTourPlanId { get; set; }
        [ForeignKey("EmpTourPlanId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        [Required]
        public DateTime DateOfWorkIn { get; set; }
        [Required]
        public string TimeOfWorkIn { get; set; }
        [Required]
        public DateTime DateOfWorkOut { get; set; }
        [Required]
        public string TimeOfWorkOut { get; set; }
        [Required]
        public double DAPercentageAdmissible { get; set; }
        [Required]
        public double DAAmount { get; set; }
        [Required]
        public double DAApprovedAmount { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Remark { get; set; }

    }
}
