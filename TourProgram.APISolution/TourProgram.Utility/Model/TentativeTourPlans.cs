using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.Model.Dtos.EmpTourPlanDtos
{
    public class TentativeTourPlans
    {
        public string Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string TravelMode { get; set; }
        public string ClassOfCity { get; set; }
        public string Remark { get; set; }
    }
}
