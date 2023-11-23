
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.TourStatus;

namespace TourProgram.BAL.Repository.Interface
{
    public interface ITourStatusRepository
    {
        public Task<ResponeModel> UpdateTourRequestAmount(TourRequestAmountStatusModel statusModel); 
        public Task<ResponeModel> UpdateTourRequestStatus(TourRequestStatusModel statusModel); 
    }
}
