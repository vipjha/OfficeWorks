using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.Model.Dtos.UsersDtos
{
    public class LoginDto
    {
        [Required]
        public int EmpCode { get; set; }
        
    }
}
