using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourProgram.DAL.Models
{
    public class EMPClaimProcessDetail 
    {
        [Key]
        public long Id { get; set; }
        public long EmpTourId { get; set; }
        [ForeignKey("EmpTourId")]
        public virtual EmpTourPlan EmpTourPlan { get; set; }
        public long SenderId{ get; set; }
        public long RecipientId { get; set; }
        public long ClaimTypeId { get; set; }
        [ForeignKey("ClaimTypeId")]
        public virtual ClaimType ClaimType { get; set; }
        public long StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual ClaimStatusCategory ClaimStatusCategory { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
