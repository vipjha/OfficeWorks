using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL;
using TourProgram.DAL.Models;
using TourProgram.Model.Dtos.ActualTravelPlanDtos;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Concrete
{
    public class ActualTravelPlanRepository : GenricRepository<ActualTravelPlan>, IActualTravelPlanRepository
    {
        private readonly TourProgramDbContext _dbContext;

        public ActualTravelPlanRepository(TourProgramDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task<ResponeModel> Create(ActualTravelPlanDto actualTravelPlanDto)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (actualTravelPlanDto != null)
            {
                ActualTravelPlan actualTravelPlan = new ActualTravelPlan()
                {
                    EmpTourPlanId = actualTravelPlanDto.EmpTourPlanId,
                    Date = actualTravelPlanDto.Date,
                    From = actualTravelPlanDto.From,
                    To = actualTravelPlanDto.To,
                    TravelMode = actualTravelPlanDto.TravelMode,
                    TourDetails = actualTravelPlanDto.TourDetails,
                    ClassOfCity = actualTravelPlanDto.ClassOfCity,
                    //CreatedBy = tentativeTravelPlanDto.EmpId,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(actualTravelPlan);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = actualTravelPlan;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Actual Travel Plan created successfully.";
            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback
            return responeModel;
        }

        public Task<ResponeModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var actualTravelPlan = await _dbContext.ActualTravelPlans.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToListAsync();
            responeModel.Data = actualTravelPlan;
            responeModel.DataLength = actualTravelPlan.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = actualTravelPlan.Count + " Travel Plan data found ";
            return responeModel;
        }

        public Task<ResponeModel> Update(ActualTravelPlanDto actualTravelPlanDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}
