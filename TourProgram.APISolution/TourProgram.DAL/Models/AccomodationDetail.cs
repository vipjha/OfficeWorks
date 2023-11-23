using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class AccomodationDetail : BaseModel
    {
        [Required]
        public long EmpTourPlanId { get; set; }
        [ForeignKey("EmpTourPlanId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        [Required]
        public DateTime DateOfCheckIn { get; set; }
        [Required]
        public string TimeOfCheckIn { get; set; }
        [Required]
        public DateTime DateOfCheckOut { get; set; }
        [Required]
        public string TimeOfCheckOut { get; set; }
        [Required]
        public string HotelName { get; set; }
        [Required]
        public string HotelCity { get; set; }
        [Required]
        public string ClassOfCity { get; set; }
        [Required]
        public bool IsFreeAccomodation { get; set; }
        [Required]
        public double BilledAmount { get; set; }
        [Required]
        public double ClaimedAmount { get; set; }
        public double? ApprovedAmount { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Remark { get; set; }

    }
}
