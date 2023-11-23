using HealthClaim.Utility.Eumus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace HealthClaim.Model.Dtos.EmpAdvance
{
    public class EmpClaimProcessDetailsModel
    {
        [Required]
        public long AdvanceId { get; set; }
        [Required]
        public long SenderId { get; set; }
        [Required]
        public long RecipientId { get; set; }
        [Required]
        public RecordMasterClaimTypes ClaimTypeId { get; set; }
        [Required]
        public RecordMasterClaimStatusCategory StatusId { get; set; }
        [Required]
        public double ApprovalAmount { get; set; }
        //public bool? IsPostHospitalization { get; set; }
        public HospitalizationBillApprovel HospitalizationBillApprovelDetails { get; set; }
        public bool? IsSpecialDisease { get; set; }
        public bool? IsTaxable { get; set; }
    }
    public class HospitalizationBillApprovel
    {
        public double MedicineAmount { get; set; }
        public double MedicineNotInAmount { get; set; }
        public double ConsultationAmount { get; set; }
        public double ConsultationNotInAmount { get; set; }
        public double InvestigationAmount { get; set; }
        public double InvestigationNotInAmount { get; set; }
        public double RoomRentAmount { get; set; }
        public double ProcedureAmount { get; set; }
        public double? OtherAmount { get; set; }
        public double? OtherNotInAmount { get; set; }
    }
    
}
