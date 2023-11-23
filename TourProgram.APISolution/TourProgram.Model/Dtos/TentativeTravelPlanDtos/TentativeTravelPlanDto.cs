using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.Model.Dtos.TentativeTravelPlanDtos
{
    public class TentativeTravelPlanDto
    {
        public long EmpTourPlanId { get; set; }
        public DateTime Date { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string TravelMode { get; set; }
        public string TourDetails { get; set; }
        public string ClassOfCity { get; set; }
    }
}
