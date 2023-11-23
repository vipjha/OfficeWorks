using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpPreHospitalizationApprovel:BaseModel
    {
        public long EmpPreHospitalzationId { get; set; }
        [ForeignKey("EmpPreHospitalzationId")]
        public virtual EmpPreHospitalization EmpPreHospitalization { get; set; }
        public double MedicineAmount { get; set; }
        public double ConsultationAmount { get; set; }
        public double InvestigationAmount { get; set; }
        public double ProcedureAmount { get; set; }
        public double? OtherAmount { get; set; }

    }
}
