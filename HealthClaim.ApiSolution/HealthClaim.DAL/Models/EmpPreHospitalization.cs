using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpPreHospitalization : BaseModel
    {
        public long EmpClaimId { get; set; }
        [ForeignKey("EmpId")]
        public virtual EmpClaim EmpClaim { get; set; }
        public double MedicineAmount { get; set; }
        public double ConsultationAmount { get; set; }
        public double InvestigationAmount { get; set; }
        public double ProcedureAmount { get; set; }
        public double? OtherAmount { get; set; }

        public double MedicineClaimAmount { get; set; }
        public double ConsultationClaimAmount { get; set; }
        public double InvestigationClaimAmount { get; set; }
        public double ProcedureClaimAmount { get; set; }
        public double? OtherClaimAmount { get; set; }

        public DateTime MedicineClaimDate { get; set; }
        public DateTime ConsultationClaimDate { get; set; }
        public DateTime InvestigationClaimDate { get; set; }
        public DateTime ProcedureClaimDate { get; set; }
        public DateTime? OtherClaimDate { get; set; }
    }
}
