using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class ClaimClarification : BaseModel
    {
        public long EmpTourPlanId { get; set; }
        [ForeignKey("EmpTourPlanId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        public string TransportationClarification { get; set; }
        public string? AccomodationClarification { get; set; }
        public string? DAClarification { get; set; }
        public string? LeaveClarification { get; set; }
        [Required]
        public int SenderId { get; set; }
        [Required]
        public int ReciverId { get; set; }
    }
}
