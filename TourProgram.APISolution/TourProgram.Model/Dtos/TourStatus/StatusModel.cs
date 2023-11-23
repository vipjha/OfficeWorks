

using HealthClaim.Utility.Eumus;
using System.ComponentModel.DataAnnotations;

namespace TourProgram.Model.Dtos.TourStatus
{
    public class TourRequestAmountStatusModel
    {
        [Required]
        public int EmpId { get; set; }
        [Required]
        public int TourId { get; set; }

        //public int? ReciverId { get; set; }
        [Required]
        public int ApprovedAmount { get; set; }
        //public string? SAPReferenceNo { get; set; }

        //public DateTime? SAPReferenceDate { get; set; }
        //public RecordMasterClaimStatus? StatusId { get; set; }
        [Required]
        public RecordMasterClaimTypes ClaimTypeId { get; set; }
    }
}
