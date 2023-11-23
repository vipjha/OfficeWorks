using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpClaimNotInMainBill:BaseModel
    {
        public long ClaimBillId { get; set; }
        [ForeignKey("ClaimBillId")]
        public virtual EmpClaimBill EmpClaimBill { get; set; }
        [Required]
        public string BillType { get; set; }
        [Required]
        public double Amount { get; set; }
        public double AmountClaim { get; set; }
    }
}
