

using HealthClaim.Utility.Eumus;
using System.ComponentModel.DataAnnotations;

namespace TourProgram.Model.Dtos.TourStatus
{
    public class TourRequestStatusModel
    {
        [Required]
        public int TourId { get; set; }
        [Required]
        public int EmpId { get; set; }
        [Required]
        public RecordMasterClaimTypes ClaimTypeId { get; set; }
        [Required]
        public RecordMasterTourRequestStatus StatusId { get; set; }
        
    }
}
