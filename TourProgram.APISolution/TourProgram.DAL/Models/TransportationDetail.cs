using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class TransportationDetail : BaseModel
    {
        public long EmpTourPlanId { get; set; }
        [ForeignKey("EmpTourPlanId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        [Required]
        public DateTime DateOfTravelSource { get; set; }
        [Required]
        public string TimeOfTravelSource { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string ModeOfTravel { get; set; }
        [Required]
        public DateTime DateOfTravelDestination { get; set; }
        [Required]
        public string TimeOfTravelDestiNation { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public double BilledAmount { get; set; }
        [Required]
        public double ClaimedAmount { get; set; }
        [Required]
        public double? ApprovedAmount { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Remark { get; set; }

    }
}
