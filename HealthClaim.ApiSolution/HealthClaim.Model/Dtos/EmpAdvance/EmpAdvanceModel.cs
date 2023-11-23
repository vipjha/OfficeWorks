using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace HealthClaim.Model.Dtos.EmpAdvance
{
    public class EmpAdvanceModel
    {
        public long EmplId { get; set; }
        public long PatientId { get; set; }
        public string RequestName { get; set; }
        public double AdvanceAmount { get; set; }
        public double EstimateAmount { get; set; }
        public string Reason { get; set; }
        public string PayTo { get; set; }

        public string? HospitalName { get; set; }
        public string? HospitalRegNo { get; set; }
        
        public DateTime? DateOfAdmission { get; set; }

        public string? DoctorName { get; set; }
        public List<IFormFile> AdmissionAdviceFile { get; set; }
        public List<IFormFile> EstimateAmountFile { get; set; }

        public string? BankName { get; set; }
        public string? BeneficiaryAccountNo { get; set; }
        public string? IFSCCode { get; set; }
        public string? BeneficiaryName { get; set; }
        public DateTime LikelyDateofAddmison { get; set; }
        public string Digonosis { get; set; }
        public string TreatmentType { get; set; }
        public bool IsHospitialEmpanpanelled { get; set; }
        public string? HospitalId { get; set; }
        public string? HospitalGSTNumber { get; set; }
        public string? BranchName { get; set; }
    }
}
