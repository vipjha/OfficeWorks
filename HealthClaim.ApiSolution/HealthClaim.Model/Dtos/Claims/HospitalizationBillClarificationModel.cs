
using HealthClaim.Utility.Eumus;
using System.ComponentModel.DataAnnotations;

namespace HealthClaim.Model.Dtos.Claims
{
    public class HospitalizationBillClarificationModel
    {
        [Required]
        public long AdvanceId { get; set; }
        [Required]
        public long SenderId { get; set; }
        [Required]
        public RecordMasterClaimTypes ClaimTypeId { get; set; }
        public string? Medicine { get; set; }
        public string? MedicineNotIn { get; set; }
        public string? Consultation { get; set; }
        public string? ConsultationNotIn { get; set; }
        public string? Investigation { get; set; }
        public string? InvestigationNotIn { get; set; }
        public string? RoomRent { get; set; }
        public string? Procedure { get; set; }
        public string? Other { get; set; }
        public string? OtherNotIn { get; set; }
        public string? OverallClarification { get; set; }
       
    }
}
