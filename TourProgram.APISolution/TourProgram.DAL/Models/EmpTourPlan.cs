using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class EmpTourPlan : BaseModel
    {
        [Required]
        public int EmpId { get; set; }
        [Required]
        public string PurposeOfTour { get; set; }
        [Required]
        public string TypeOfTour { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public DateTime TantetiveDateOfDeparture { get; set; }
        [Required]
        public int NoOfDays { get; set; }
        public bool? IsRoad { get; set; }
        public bool? IsRail { get; set; }
        public bool? IsAir { get; set; }
        [Required]
        public string ClassOfCity { get; set; }
        [Required]
        public string Grade { get; set; }
        public double? TravelEstimateAmount { get; set; }
        public double? AccomodationEstimate { get; set; }
        public double? AdvanceRequired { get; set; }
        public double? ApprovedAmount { get; set; }
        public bool? IsX { get; set; }
        public bool? IsY { get; set; }
        public bool? IsZ { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public double? PaidAmount { get; set; }
        public double? PaymentReferenceNo { get; set; }
        public bool? IsDirectClaim { get; set; }
        public bool? IsAdvanceLiquidated { get; set; }
        public DateTime? DateOfLiquidation { get; set; }
        public int? LiquiDationBy { get; set; }
        public bool? IsAdvanceRequired { get; set; }

    }
}
