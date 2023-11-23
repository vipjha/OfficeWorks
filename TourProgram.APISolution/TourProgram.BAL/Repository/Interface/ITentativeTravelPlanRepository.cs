using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.TentativeTravelPlanDtos;

namespace TourProgram.BAL.Repository.Interface
{
    public interface ITentativeTravelPlanRepository
    {
        public Task<ResponeModel> Create(TentativeTravelPlanDto tentativeTravelPlanDto);
        public Task<ResponeModel> Update(TentativeTravelPlanDto tentativeTravelPlanDto, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> Get(int? id);
    }
}
