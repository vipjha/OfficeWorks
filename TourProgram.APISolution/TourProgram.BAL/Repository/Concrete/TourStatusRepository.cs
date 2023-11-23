using HealthClaim.Utility.Eumus;
using Microsoft.EntityFrameworkCore.Storage;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL;
using TourProgram.DAL.Models;
using TourProgram.Model.Dtos.EmpTourPlanDtos;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.TourStatus;

namespace TourProgram.BAL.Repository.Concrete
{
    public class TourStatusRepository : GenricRepository<EMPClaimProcessDetail>, ITourStatusRepository
    {
        private readonly TourProgramDbContext _dbContext;
        public TourStatusRepository(TourProgramDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task<ResponeModel> UpdateTourRequestStatus(TourRequestStatusModel statusModel)
        {
            ResponeModel responeModel = new ResponeModel();

            if (statusModel != null)
            {
                var tourPlan = _dbContext.EmpTourPlans.Where(f => f.Id == statusModel.TourId).FirstOrDefault();
                if (tourPlan != null)
                {
                    IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
                    EMPClaimProcessDetail empClaimProcessDetails = new EMPClaimProcessDetail()
                    {
                        EmpTourId = statusModel.TourId,
                        ClaimTypeId = ((long)statusModel.ClaimTypeId),
                        StatusId = ((long)statusModel.StatusId),
                        SenderId = statusModel.EmpId,
                        RecipientId = Convert.ToInt32(tourPlan.EmpId),
                        CreatedBy = statusModel.EmpId,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };
                    await _dbContext.AddAsync(empClaimProcessDetails);
                    await _dbContext.SaveChangesAsync();

                    //tourPlan.ApprovedAmount = 0;
                    //tourPlan.ApprovedBy = statusModel.EmpId;
                    //tourPlan.ApprovedDate = DateTime.Now;
                    //tourPlan.UpdatedDate = DateTime.Now;
                    //tourPlan.UpdatedBy = statusModel.EmpId;

                    //_dbContext.Update(tourPlan);
                    //await _dbContext.SaveChangesAsync();

                    transaction.Commit();
                    responeModel.Data = "";
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Status updated successfuly.";
                }
                else
                {
                    responeModel.Data = "";
                    responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                    responeModel.Error = false;
                    responeModel.Message = "Tour id is not valid.";
                }

            }
            return responeModel;
        }

        public async Task<ResponeModel> UpdateTourRequestAmount(TourRequestAmountStatusModel statusModel)
        {
            ResponeModel responeModel = new ResponeModel();

            if (statusModel != null)
            {
                var tourPlan = _dbContext.EmpTourPlans.Where(f => f.Id == statusModel.TourId).FirstOrDefault();
                if (tourPlan != null)
                {
                    IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

                   
                        //EMPClaimProcessDetail empClaimProcessDetails = new EMPClaimProcessDetail()
                        //{
                        //    EmpTourId = statusModel.TourId,
                        //    ClaimTypeId = ((long)statusModel.ClaimTypeId),
                        //    StatusId = ((long)statusModel.StatusId),
                        //    SenderId = statusModel.EmpId,
                        //    RecipientId = Convert.ToInt32(statusModel.ReciverId),
                        //    CreatedBy = statusModel.EmpId,
                        //    CreatedDate = DateTime.Now,
                        //    IsActive = true,
                        //};
                        //await _dbContext.AddAsync(empClaimProcessDetails);
                        //await _dbContext.SaveChangesAsync();
                    

                    tourPlan.ApprovedAmount = statusModel.ApprovedAmount;
                    tourPlan.ApprovedBy = statusModel.EmpId;
                    tourPlan.ApprovedDate = DateTime.Now;
                    tourPlan.UpdatedDate = DateTime.Now;
                    tourPlan.UpdatedBy = statusModel.EmpId;

                    _dbContext.Update(tourPlan);
                    await _dbContext.SaveChangesAsync();


                    var _financeDetails = new FinanceDetail()
                    {
                        EmpTourPlanId = statusModel.TourId,
                        ClaimTypeId = ((long)statusModel.ClaimTypeId),
                        ApprovedAmount= statusModel.ApprovedAmount,
                        CreatedBy= statusModel.EmpId,
                        CreatedDate=DateTime.Now,
                        IsActive=true,
                    };

                    _dbContext.Add(_financeDetails);
                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();
                    responeModel.Data = "";
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Request updated successfuly.";
                }
                else
                {
                    responeModel.Data = "";
                    responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                    responeModel.Error = false;
                    responeModel.Message = "Tour id is not valid.";
                }

            }

            return responeModel;
        }
    }
}
