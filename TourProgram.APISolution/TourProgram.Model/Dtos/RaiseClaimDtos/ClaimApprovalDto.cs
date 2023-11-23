using System.ComponentModel.DataAnnotations;

namespace TourProgram.Model.Dtos.RaiseClaimDtos
{
    public class ClaimApprovalDto
    {
        [Required]
        public long EmpTourPlanId { get; set; }
        [Required]
        public string PurposeOfTour { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public DateTime TentativeDateOfDeparture { get; set; }
        [Required]
        public int NumberOfDays { get; set; }
        /*public bool IsAir { get; set;}
        public bool IsRail { get; set;}
        public bool IsRoad { get; set;}*/
        // public List<IFormFile> UploadFiles { get;set;}
        //public List<TransportaionDetailDto>  TransportaionDetailDtos { get;set;}
        public string TransportaionDetailDtos { get; set; }
        //public List<AccomodationDetailDto> AccomodationDetailDto { get;set;}
        public string AccomodationDetailDto { get; set; }
        public string? DailyAllowanceDto { get; set; }
        public string? LeaveAvailedDto { get; set; }
    }

    public class TransportaionDetailDto
    {
        public long EmpTourPlanId { get; set; }
        public DateTime DateOfTravelSource { get; set; }
        public string TimeOfTravelSource { get; set; }
        public string Source { get; set; }
        public string ModeOfTravel { get; set; }
        public DateTime DateOfTravelDestination { get; set; }
        public string TimeOfTravelDestiNation { get; set; }
        public string Destination { get; set; }
        public double BilledAmount { get; set; }
        public double ClaimedAmount { get; set; }
        /*public double? ApprovedAmount { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Remark { get; set; }*/
        public List<TransportationUploadDto> TransportationUploadDto { get; set; }
    }

    public class TransportationUploadDto
    {
        public long TransportationDetailsId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }

    public class AccomodationDetailDto
    {
        public long EmpTourPlanId { get; set; }
        public DateTime DateOfCheckIn { get; set; }
        public string TimeOfCheckIn { get; set; }
        public DateTime DateOfCheckOut { get; set; }
        public string TimeOfCheckOut { get; set; }
        public string HotelName { get; set; }
        public string HotelCity { get; set; }
        public string ClassOfCity { get; set; }
        public bool IsFreeAccomodation { get; set; }
        public double BilledAmount { get; set; }
        public double ClaimedAmount { get; set; }
        /*public double? ApprovedAmount { get; set; }
        public int? ApprovedBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? Remark { get; set; }*/
        public List<AccomodationUploadDto> AccomodationUploadDto { get; set; }
    }
    public class AccomodationUploadDto
    {
        public long AccomodationDetailsId { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
    }

    public class DailyAllowanceDto
    {
        public DateTime Date { get; set; }
        public string SourceTime { get; set; }
        public string EndTime { get; set; }
        public string DASlab { get; set; }
        public int PercentageAdmissible { get; set; }
        public double Amount { get; set; }
    }

    public class LeaveAvailedDto
    {
        public DateTime LeaveStartDate { get; set; }
        public DateTime LeaveEndDate { get; set; }
        public bool DADeductable { get; set; }
        public Double Amount { get; set; }
    }


}
