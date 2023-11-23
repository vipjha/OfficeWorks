using System.ComponentModel.DataAnnotations.Schema;

namespace HealthClaim.DAL.Models
{
    public class ClaimClarification:BaseModel
    {
        //public long EmpClaimId { get; set; }
        //[ForeignKey("EmpClaimId")]
        //public virtual EmpClaim EmployeClaim { get; set; }
        public long EmpAdvanceId { get; set; }
        [ForeignKey("EmpAdvanceId")]
        public virtual EmpAdvance EmpAdvance { get; set; }

        public long ClaimTypeId { get; set; }
        [ForeignKey("ClaimTypeId")]
        public virtual ClaimType ClaimType { get; set; }
        public string ClarificationKey { get; set; }
        public string ClarificationValue { get; set; }
        public long SenderId { get; set; }
        [ForeignKey("SenderId")]
        public virtual Employee EmployeeSender { get; set; }

        public long RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public virtual Employee EmployeeRecipient { get; set; }

    }
}
