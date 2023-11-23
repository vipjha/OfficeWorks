using System.ComponentModel.DataAnnotations;

namespace TourProgram.DAL.Models
{
    public class ClaimType  
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}
