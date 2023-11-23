using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class FinanceBanking:BaseModel
    {
        public long FinanceBillPassingId { get; set; }
        [ForeignKey("FinanceBillPassingId")]
        public virtual FinanceBillPassing FinanceBillPassing { get; set; }

        public DateTime SapReferenceDate { get; set; }
        public string SapRefNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string UTRNo { get; set; }
    }
}
