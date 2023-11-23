using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.Model.Dtos.EmpTourPlanDtos
{
    public class ApproverDetailsDto
    {
        public string ApprovalDate { get; set; }
        public double? ApprovedAmount { get; set; }
        public int? ApprovedById { get; set; }
        public string ApprovedBy { get; set; }
        public string FilePath { get; set; }
    }
}
