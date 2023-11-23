using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpClaimNotInMainBillApprovel : BaseModel
    {
        public long EmpClaimNotInMainBillId { get; set; }
        [ForeignKey("EmpClaimNotInMainBillId")]
        public virtual EmpClaimNotInMainBill EmpClaimNotInMainBill { get; set; }
        public double Amount { get; set; }
    }
}
