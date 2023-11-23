using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class FinanceDetail : BaseModel
    {
        [Required]
        public long EmpTourPlanId { get; set; }
        [ForeignKey("EmpTourPlanId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        [Required]
        public long ClaimTypeId{ get; set; }
        [ForeignKey("ClaimTypeId")]
        public virtual ClaimType ClaimType { get; set; }
        [Required]
        public bool IsLiquidation { get; set;}
        public string? SapReferenceNoPaymentApproval{ get; set; }
        public DateTime? SapReferenceDatePaymentApproval{ get; set; }
        public DateTime? SapReferenceNoLiquidation{ get; set; }
        public DateTime? SapReferenceDateLiquidation { get; set; }
        public string? SapReferenceNoPaymentProcessing { get; set; }
        public DateTime? SapReferenceDatePaymentProcessing { get; set; }
        public double? LiquidationAmount { get; set; }
        public double? ApprovedAmount { get; set; }
        public double? PaidAmount{ get; set; }
        public string? UTRNO { get; set; }
        public DateTime? UTRProcessDate { get; set; }
    }
}
