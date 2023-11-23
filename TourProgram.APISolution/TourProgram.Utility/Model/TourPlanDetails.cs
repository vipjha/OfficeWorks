using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.Model.Dtos.EmpTourPlanDtos
{
    public class TourPlanDetails
    {
        public string EmployeeNo { get; set; }

        public string EmployeeName { get; set; }
        public string Designation { get; set; }
        public string PurposeOfTour { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string EmployeeDepartment { get; set; }
        public string TentativeStartDate { get; set; }
        public string NoOfDays { get; set; }
        public string Units { get; set; }
        public string Lavel { get; set; }
    }
}
