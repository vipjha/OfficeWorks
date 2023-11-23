

using System.ComponentModel.DataAnnotations;

namespace TourProgram.Model.Dtos.UsersDtos
{
    public class VerifyOtpCodeModel
    {
        [Required]
        public int OTPCode { get; set; }
        [Required]
        public int EmpId { get; set; }
    }
}
