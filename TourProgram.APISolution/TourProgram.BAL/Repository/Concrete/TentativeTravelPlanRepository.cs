using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL.Models;
using TourProgram.DAL;
using TourProgram.Model.Dtos.EmpTourPlanDtos;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.TentativeTravelPlanDtos;
using Microsoft.EntityFrameworkCore;

namespace TourProgram.BAL.Repository.Concrete
{
    public class TentativeTravelPlanRepository : GenricRepository<TentativeTravelPlan>, ITentativeTravelPlanRepository
    {
        private readonly TourProgramDbContext _dbContext;

        public TentativeTravelPlanRepository(TourProgramDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task<ResponeModel> Create(TentativeTravelPlanDto tentativeTravelPlanDto)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (tentativeTravelPlanDto != null)
            {
                TentativeTravelPlan tentativeTravelPlan = new TentativeTravelPlan()
                {
                    EmpTourPlanId = tentativeTravelPlanDto.EmpTourPlanId,
                    Date = tentativeTravelPlanDto.Date,
                    From = tentativeTravelPlanDto.From,
                    To = tentativeTravelPlanDto.To,
                    TravelMode = tentativeTravelPlanDto.TravelMode,
                    TourDetails = tentativeTravelPlanDto.TourDetails,
                    ClassOfCity = tentativeTravelPlanDto.ClassOfCity,
                    //CreatedBy = tentativeTravelPlanDto.EmpId,
                    CreatedDate = DateTime.Now
                };
                _dbContext.Add(tentativeTravelPlan);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = tentativeTravelPlan;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Tentative Travel Plan created successfully.";
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
            var tentativeTravelPlan = await _dbContext.TentativeTravelPlans.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToListAsync();
            responeModel.Data = tentativeTravelPlan;
            responeModel.DataLength = tentativeTravelPlan.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = tentativeTravelPlan.Count + " Travel Plan data found ";
            return responeModel;
        }

        public Task<ResponeModel> Update(TentativeTravelPlanDto tentativeTravelPlanDto, int id)
        {
            throw new NotImplementedException();
        }
    }
}