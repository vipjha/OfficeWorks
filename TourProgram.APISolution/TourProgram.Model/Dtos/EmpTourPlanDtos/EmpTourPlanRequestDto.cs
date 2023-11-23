using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace TourProgram.Model.Dtos.EmpTourPlanDtos
{
    public class EmpTourPlanRequestDto
    {
        [Required]
        public int EmpId { get; set; }
        [Required]
        public string PurposeOfTour { get; set; }
        [Required]
        public string TypeOfTour { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public DateTime TantetiveDateOfDeparture { get; set; }
        [Required]
        public int NoOfDays { get; set; }
        public bool? IsRoad { get; set; }
        public bool? IsRail { get; set; }
        public bool? IsAir { get; set; }
        [Required]
        public string ClassOfCity { get; set; }
        [Required]
        public string Grade { get; set; }
        //public double? TravelEstimateAmount { get; set; }
        //public double? AccomodationEstimate { get; set; }
        public double? AdvanceRequired { get; set; }
        
        public bool? IsX { get; set; }
        public bool? IsY { get; set; }
        public bool? IsZ { get; set; }
        
        public double? PaidAmount { get; set; }
        public bool? IsDirectClaim { get; set; }
      
       
        [Required]
        public bool IsAdvanceRequired { get; set; }
        public TourTravelEstimate? TourTravelEstimate { get; set; }
        public TourAccommodationEstimate? TourAccommodationEstimate { get; set; }
        

        [Required]
        public string TentativeTravelPlans { get; set; }
        [Required]
        public int ManagerId { get; set; }

    }

    public class TourTravelEstimate
    {
        public List<IFormFile>? TravelFiles { get; set; }
        public int? EstimatedAmount	 { get; set; }
    }
    public class TourAccommodationEstimate
    {
        public List<IFormFile>? AccommodationFiles { get; set; }
        public int? EstimatedAmount	 { get; set; }
       /* public bool? ClassOfCity_X { get; set; }
        public bool? ClassOfCity_Y { get; set; }
        public bool? ClassOfCity_Z { get; set; }*/
    }
    public class TentativeTravelPlanRequestDto
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string From { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string TravelMode { get; set; }
        public string? TourDetails { get; set; }
        public string? ClassOfCity { get; set; }
    }
}
