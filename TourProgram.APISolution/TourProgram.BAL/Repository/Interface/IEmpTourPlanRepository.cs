using TourProgram.Model.Dtos.EmpTourPlanDtos;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Interface
{
    public interface IEmpTourPlanRepository
    {
        //public Task<ResponeModel> Create(EmpTourPlanDto empTourPlanDetails);
        public Task<ResponeModel> Update(EmpTourPlanDto empTourPlanDetails, int id);
        public Task<ResponeModel> GetTourDetails(int id, string baseUrl);
        Task<ResponeModel> EmpTourRequest(EmpTourPlanRequestDto empTourPlanRequestDto);
        Task<ResponeModel> GetGradeData(string level);
        Task<ResponeModel> EmpTourApprovedAmount(EmpTourApprovedDto empTourApprovedDto, int id);
    }
}
