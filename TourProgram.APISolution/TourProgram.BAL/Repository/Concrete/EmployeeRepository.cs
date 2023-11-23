using Newtonsoft.Json;
using Org.BouncyCastle.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.Employee;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Concrete
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<EmployeeDetails> GetEmployeeDetails(int empId)
        {
            EmployeeDetails employeeDetails = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://uat.dfccilorganization.services.cetpainfotech.com/api/Organization/GetReporting/" + empId + "");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                if (apiResponse != null)
                {
                    ResponeModel respone = JsonConvert.DeserializeObject<ResponeModel>(apiResponse);
                    if (!Equals(respone.Data,null))
                    {
                        employeeDetails = JsonConvert.DeserializeObject<EmployeeDetails>(respone.Data.ToString());
                    }
                }
            }
            return employeeDetails;
        }

        public async Task<EmployeeDetails> GetEmployeeDetailsWithEmpCode(int empCode)
        {
            EmployeeDetails employeeDetails = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://uat.dfccilorganization.services.cetpainfotech.com/api/Organization/GetEmployeDetailsWithEmpCode/" + empCode + "");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                if (apiResponse != null)
                {
                    ResponeModel respone = JsonConvert.DeserializeObject<ResponeModel>(apiResponse);
                    if (!Equals(respone.Data, null))
                    {
                        employeeDetails = JsonConvert.DeserializeObject<EmployeeDetails>(respone.Data.ToString());
                    }
                }
            }
            return employeeDetails;
        }
    }
}
