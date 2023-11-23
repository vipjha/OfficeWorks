using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProgram.Model.Dtos.ActualTravelPlanDtos;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.TentativeTravelPlanDtos;

namespace TourProgram.BAL.Repository.Interface
{
    public interface IActualTravelPlanRepository
    {
        public Task<ResponeModel> Create(ActualTravelPlanDto actualTravelPlanDto);
        public Task<ResponeModel> Update(ActualTravelPlanDto actualTravelPlanDto, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> Get(int? id);
    }
}
