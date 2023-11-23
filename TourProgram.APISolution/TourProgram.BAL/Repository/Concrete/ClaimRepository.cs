using HealthClaim.Utility.Eumus;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL;
using TourProgram.DAL.Models;
using TourProgram.Model.Dtos.RaiseClaimDtos;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Concrete
{
    public class ClaimRepository : GenricRepository<EmpTourPlan>, IClaimRepository
    {
        private readonly TourProgramDbContext _dbContext;
        private readonly ICommanRepository _commandRepo;

        public ClaimRepository(TourProgramDbContext db, ICommanRepository commandRepo) : base(db)
        {
            _dbContext = db;
            _commandRepo = commandRepo;
        }


        public async Task<ResponeModel> RaiseClaimRequest(ClaimApprovalDto claimApprovalDto)
        {
            ResponeModel responeModel = new ResponeModel();
            //IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (claimApprovalDto != null)
            {
                var empTourDetails = _dbContext.EmpTourPlans.Where(x => x.Id == claimApprovalDto.EmpTourPlanId).FirstOrDefault();
                empTourDetails.EmpId = empTourDetails.EmpId;
                empTourDetails.PurposeOfTour = empTourDetails.PurposeOfTour != null ? empTourDetails.PurposeOfTour : claimApprovalDto.PurposeOfTour;
                empTourDetails.Destination = claimApprovalDto.Destination;
                empTourDetails.Source = empTourDetails.Source != null ? empTourDetails.Source : claimApprovalDto.Source;
                empTourDetails.TantetiveDateOfDeparture = empTourDetails.TantetiveDateOfDeparture != null ? empTourDetails.TantetiveDateOfDeparture : claimApprovalDto.TentativeDateOfDeparture;
                empTourDetails.NoOfDays = empTourDetails.NoOfDays != null ? empTourDetails.NoOfDays : claimApprovalDto.NumberOfDays;
                empTourDetails.ClassOfCity = empTourDetails.ClassOfCity;
                empTourDetails.Grade = empTourDetails.Grade;
                empTourDetails.PaidAmount = empTourDetails?.PaidAmount;
                // PaymentReferenceNo = empTourPlanRequestDto.PaymentReferenceNo,
                empTourDetails.IsDirectClaim = empTourDetails?.IsDirectClaim;
                empTourDetails.IsAdvanceRequired = empTourDetails?.IsAdvanceRequired;
                empTourDetails.UpdatedBy = empTourDetails.EmpId;
                empTourDetails.UpdatedDate = DateTime.Now;

                _dbContext.Update(empTourDetails);
                await _dbContext.SaveChangesAsync();

                if (claimApprovalDto.TransportaionDetailDtos != null)
                {
                    var jsonString = JsonConvert.DeserializeObject(claimApprovalDto.TransportaionDetailDtos);

                    var transportationDetailsData = JsonConvert.DeserializeObject<List<TransportaionDetailDto>>(jsonString.ToString());

                    List<TransportationDetail> transportationDetailsList = new List<TransportationDetail>();
                    if (transportationDetailsData != null)
                    {
                        foreach (var item in transportationDetailsData)
                        {
                            TransportationDetail transportationDetailSingle = new();
                            {
                                transportationDetailSingle.EmpTourPlanId = empTourDetails.Id;
                                transportationDetailSingle.DateOfTravelSource = item.DateOfTravelSource;
                                transportationDetailSingle.TimeOfTravelSource = item.TimeOfTravelSource;
                                transportationDetailSingle.Source = item.Source;
                                transportationDetailSingle.ModeOfTravel = item.ModeOfTravel;
                                transportationDetailSingle.DateOfTravelDestination = item.DateOfTravelDestination;
                                transportationDetailSingle.TimeOfTravelDestiNation = item.TimeOfTravelDestiNation;
                                transportationDetailSingle.Destination = item.Destination;
                                transportationDetailSingle.BilledAmount = item.BilledAmount;
                                transportationDetailSingle.ClaimedAmount = item.ClaimedAmount;
                                transportationDetailSingle.CreatedBy = empTourDetails.EmpId;
                                transportationDetailSingle.CreatedDate = DateTime.Now;
                            }
                            //transportationDetailsList.Add(transportationDetailSingle);

                            _dbContext.Add(transportationDetailSingle);
                            await _dbContext.SaveChangesAsync();

                            if (item.TransportationUploadDto != null)
                            {
                                List<TransportationUpload> transportUploadList = new List<TransportationUpload>();
                                foreach (var uploadItem in item.TransportationUploadDto)
                                {
                                    //var UploadDocuments = await UploadTansportationFile(item.TransportationUploadDto, "TourTravelEstimate");

                                    TransportationUpload transportationUploadSingle = new();
                                    {
                                        transportationUploadSingle.TransportationDetailsId = transportationDetailSingle.Id;
                                        transportationUploadSingle.FileName = uploadItem.FileName;
                                        transportationUploadSingle.FilePath = uploadItem.FilePath;
                                    };
                                    transportUploadList.Add(transportationUploadSingle);
                                }
                                _dbContext.AddRange(transportUploadList);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                    }
                }
                if (claimApprovalDto.AccomodationDetailDto != null)
                {
                    var jsonString = JsonConvert.DeserializeObject(claimApprovalDto.AccomodationDetailDto);

                    var accomodationDetailsData = JsonConvert.DeserializeObject<List<AccomodationDetailDto>>(jsonString.ToString());

                    List<AccomodationDetail> accomodationDetailsList = new List<AccomodationDetail>();

                    if (accomodationDetailsData != null)
                    {
                        foreach (var item in accomodationDetailsData)
                        {
                            AccomodationDetail accomodationDetailSingle = new();
                            {
                                accomodationDetailSingle.EmpTourPlanId = empTourDetails.Id;
                                accomodationDetailSingle.DateOfCheckIn = item.DateOfCheckIn;
                                accomodationDetailSingle.TimeOfCheckIn = item.TimeOfCheckIn;
                                accomodationDetailSingle.DateOfCheckOut = item.DateOfCheckOut;
                                accomodationDetailSingle.TimeOfCheckOut = item.TimeOfCheckOut;
                                accomodationDetailSingle.HotelName = item.HotelName;
                                accomodationDetailSingle.HotelCity = item.HotelCity;
                                accomodationDetailSingle.ClassOfCity = item.ClassOfCity;
                                accomodationDetailSingle.IsFreeAccomodation = item.IsFreeAccomodation;
                                accomodationDetailSingle.BilledAmount = item.BilledAmount;
                                accomodationDetailSingle.ClaimedAmount = item.ClaimedAmount;
                                accomodationDetailSingle.CreatedBy = empTourDetails.EmpId;
                                accomodationDetailSingle.CreatedDate = DateTime.Now;
                            }
                            // accomodationDetailsList.Add(accomodationDetailSingle);

                            _dbContext.Add(accomodationDetailSingle);
                            await _dbContext.SaveChangesAsync();

                            if (item.AccomodationUploadDto != null)
                            {
                                List<AccomodationUpload> accomodationUploadsList = new List<AccomodationUpload>();
                                foreach (var uploadItem in item.AccomodationUploadDto)
                                {
                                    //var UploadDocuments = await UploadTansportationFile(item.TransportationUploadDto, "TourTravelEstimate");

                                    AccomodationUpload accomondationUploadSingle = new();
                                    {
                                        accomondationUploadSingle.AccomodationDetailsId = accomodationDetailSingle.Id;
                                        accomondationUploadSingle.FileName = uploadItem.FileName;
                                        accomondationUploadSingle.FilePath = uploadItem.FilePath;
                                    };
                                    accomodationUploadsList.Add(accomondationUploadSingle);
                                }
                                _dbContext.AddRange(accomodationUploadsList);
                                await _dbContext.SaveChangesAsync();
                            }
                        }
                    }
                    /*  _dbContext.AddRange(accomodationDetailsList);
                      await _dbContext.SaveChangesAsync();*/
                }
                if (claimApprovalDto.DailyAllowanceDto != null)
                {
                    var jsonString = JsonConvert.DeserializeObject(claimApprovalDto.DailyAllowanceDto);

                    var dailyAllowanceData = JsonConvert.DeserializeObject<List<DailyAllowanceDto>>(jsonString.ToString());

                    List<DADetail> daDetailList = new List<DADetail>();

                    if (dailyAllowanceData != null)
                    {
                        foreach (var item in dailyAllowanceData)
                        {
                            DADetail daDetailSingle = new();
                            {
                                daDetailSingle.EmpTourPlanId = empTourDetails.Id;
                                daDetailSingle.DateOfWorkIn = item.Date;
                                daDetailSingle.TimeOfWorkIn = item.SourceTime;
                                daDetailSingle.DateOfWorkOut = item.Date;
                                daDetailSingle.TimeOfWorkOut = item.EndTime;
                                daDetailSingle.DAPercentageAdmissible = item.PercentageAdmissible;
                                daDetailSingle.DAAmount = item.Amount;
                                daDetailSingle.CreatedBy = empTourDetails.EmpId;
                                daDetailSingle.CreatedDate = DateTime.Now;
                            }
                            daDetailList.Add(daDetailSingle);
                        }
                    }
                    _dbContext.AddRange(daDetailList);
                    await _dbContext.SaveChangesAsync();
                }
                if (claimApprovalDto.LeaveAvailedDto != null)
                {
                    var jsonString = JsonConvert.DeserializeObject(claimApprovalDto.LeaveAvailedDto);

                    var leaveAvailedData = JsonConvert.DeserializeObject<List<LeaveAvailedDto>>(jsonString.ToString());

                    List<LeaveDetail> leaveAvailedList = new List<LeaveDetail>();

                    if (leaveAvailedData != null)
                    {
                        foreach (var item in leaveAvailedData)
                        {
                            LeaveDetail leaveAvailedSingle = new();
                            {
                                leaveAvailedSingle.EmpTourPlanId = empTourDetails.Id;
                                leaveAvailedSingle.DateOfLeaveIn = item.LeaveStartDate;
                                leaveAvailedSingle.DateOfLeaveOut = item.LeaveEndDate;
                                leaveAvailedSingle.IsDADeductable = item.DADeductable;
                                leaveAvailedSingle.DADeductableAmount = item.Amount;
                                leaveAvailedSingle.CreatedBy = empTourDetails.EmpId;
                                leaveAvailedSingle.CreatedDate = DateTime.Now;
                            }
                            leaveAvailedList.Add(leaveAvailedSingle);
                        }
                    }
                    _dbContext.AddRange(leaveAvailedList);
                    await _dbContext.SaveChangesAsync();
                }

                EMPClaimProcessDetail empClaimProcessDetails = new EMPClaimProcessDetail()
                {
                    EmpTourId = empTourDetails.Id,
                    ClaimTypeId = ((long)RecordMasterClaimTypes.Advance),
                    StatusId = ((long)RecordMasterClaimStatusCategory.PendingApproval),
                    SenderId = empTourDetails.EmpId,
                    RecipientId = empTourDetails.EmpId,
                    CreatedBy = empTourDetails.EmpId,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                };

                await _dbContext.AddAsync(empClaimProcessDetails);
                await _dbContext.SaveChangesAsync();

                //transaction.Commit(); // Transaction

                responeModel.Data = "";
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Tour created successfuly";
            }
            else
            {
                responeModel.Data = null;
                responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                responeModel.Error = false;
                responeModel.Message = "Bad request.";
            }

            return null;
        }


        private async Task<List<TransportationUpload>> UploadTansportationFile(List<IFormFile> files, string floderName)
        {
            bool status = false;
            var response = await _commandRepo.UploadDocumets(files, floderName);
            List<TransportationUpload> uploadTransportDocuments = new List<TransportationUpload>();
            if (response != null && response.Count != 0)
            {
                foreach (var item in response)
                {
                    TransportationUpload uploadTransportDocument = new TransportationUpload()
                    {
                        FileName = item.fileName,
                        FilePath = item.filePath
                    };
                    uploadTransportDocuments.Add(uploadTransportDocument);
                }
            }
            return uploadTransportDocuments;
        }
    }
}
