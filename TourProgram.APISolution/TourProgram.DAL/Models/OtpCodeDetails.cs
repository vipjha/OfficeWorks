
using System.ComponentModel.DataAnnotations;

namespace TourProgram.DAL.Models
{
    public class OtpCodeDetails
    {
        [Key]
        public int Id { get; set; }
        public Int64 OtpCode { get; set; }
        public DateTime Senttime { get; set; }
        public int RequestedByEmpId { get; set; }
        public bool IsOtpVerify { get; set; }
        public DateTime? VerifyDateTime { get; set; }
    }
}
