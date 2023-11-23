
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Interface
{
    public interface ITourListingRepository
    {
        public Task<ResponeModel> GetTourRequest(int empId);
        public Task<ResponeModel> GetTourPlanList(int recipientId);
    }
}
