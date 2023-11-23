using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class FinanceBillPassing : BaseModel
    {
        public long ClaimId { get; set; }
        [ForeignKey("ClaimId")]
        public virtual EmpClaim EmpClaim { get; set; }
        public long ClaimTypeId { get; set; }
        [ForeignKey("ClaimTypeId")]
        public virtual ClaimType ClaimType { get; set; }

        public long? TopUpId { get; set; }
        [ForeignKey("TopUpId")]
        public virtual EmpAdvanceTopUp? EmpAdvanceTopUp { get; set; }

        public DateTime ReferenceDate { get; set; }
        public string SapRefNumber { get; set; }
        public double AmountPaid { get; set; }
        public string Comment { get; set; }
    }
}
