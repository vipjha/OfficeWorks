using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.Employee
{
    public class EmployeeBasicDetailsModel
    {
        public long EmpId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string EmailId { get; set; }
        public string Mobile { get; set; }
       
    }
}
