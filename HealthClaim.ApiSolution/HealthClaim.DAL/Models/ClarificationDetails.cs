using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class ClarificationDetails:BaseModel
    {
        public long AdvanceId { get; set; }
        [ForeignKey("AdvanceId")]
        public virtual EmpAdvance EmpAdvance { get; set; }

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
