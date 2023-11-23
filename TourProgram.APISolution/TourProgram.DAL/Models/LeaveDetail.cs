using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class LeaveDetail : BaseModel
    {
        [Required]
        public long EmpTourPlanId { get; set; }
        [ForeignKey("EmpTourPlanId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        [Required]
        public DateTime DateOfLeaveIn { get; set; }
        [Required]
        public string TimeOfLeaveIn { get; set; }
        [Required]
        public DateTime DateOfLeaveOut { get; set; }
        [Required]
        public string TimeOfLeaveOut { get; set; }
        [Required]
        public bool IsDADeductable { get; set; }
        [Required]
        public double DADeductableAmount { get; set; }
        public double? DADeductableApprovedAmount { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Remark { get; set; }

    }
}
