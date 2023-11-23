using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmployeeClaimBillApprovel : BaseModel
    {
        public long ClaimBillId { get; set; }
        [ForeignKey("ClaimBillId")]
        public virtual EmpClaimBill EmpClaimBill { get; set; }
        public double MedicineAmount { get; set; }
        public double ConsultationAmount { get; set; }
        public double InvestigationAmount { get; set; }
        public double RoomRentAmount { get; set; }
        public double? OtherAmount { get; set; }
        public double? ProcedureAmount { get; set; }

    }
}
