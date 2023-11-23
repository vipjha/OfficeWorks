using System.ComponentModel.DataAnnotations;

namespace HealthClaim.Web.Models.Login
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter user name.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password.")]
        public string Password { get; set; }
    }
}
