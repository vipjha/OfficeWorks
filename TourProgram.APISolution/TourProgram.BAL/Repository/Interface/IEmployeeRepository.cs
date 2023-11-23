using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProgram.Model.Dtos.Employee;

namespace TourProgram.BAL.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public Task<EmployeeDetails> GetEmployeeDetails(int empId);
        public Task<EmployeeDetails> GetEmployeeDetailsWithEmpCode(int empCode);
    }
}
