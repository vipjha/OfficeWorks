using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL.Models;
using TourProgram.DAL;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.EmpTourPlanDtos;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using HealthClaim.Utility.Eumus;
using System.Xml.Linq;
using System.Diagnostics;
using System.Security.Claims;
using TourProgram.Model.Dtos.Employee;
using TourProgram.Utility.PdfUtility;
using System.Numerics;

namespace TourProgram.BAL.Repository.Concrete
{
    public class EmpTourPlanRepository : GenricRepository<EmpTourPlan>, IEmpTourPlanRepository
    {
        private readonly TourProgramDbContext _dbContext;
        private readonly ICommanRepository _commandRepo;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly PDFGenerator _pDFGenerator;

        public EmpTourPlanRepository(TourProgramDbContext db, ICommanRepository commandRepo, 
            IEmployeeRepository employeeRepository, PDFGenerator pDFGenerator) : base(db)
        {
            _dbContext = db;
            _commandRepo = commandRepo;
            _employeeRepository = employeeRepository;
            _pDFGenerator = pDFGenerator;
        }

       
        public async Task<ResponeModel> GetTourDetails(int id, string baseUrl)
        {
            ResponeModel responeModel = new ResponeModel();

            var empTourPlan = _dbContext.EmpTourPlans.Where(f => f.Id == id).FirstOrDefault();
            if (empTourPlan != null)
            {

                EmployeeDetails employeeDetails = null;
                employeeDetails = await _employeeRepository.GetEmployeeDetails(empTourPlan.EmpId);
                TourPlanDetails EmployeeDetails = new TourPlanDetails()
                {
                    EmployeeNo = employeeDetails?.empCode,
                    EmployeeName = employeeDetails?.empName,
                    Designation = employeeDetails?.designation,
                    PurposeOfTour = empTourPlan.PurposeOfTour,
                    Source = empTourPlan.Source,
                    Destination = empTourPlan.Destination,
                    EmployeeDepartment = employeeDetails?.department,
                    TentativeStartDate = empTourPlan.TantetiveDateOfDeparture.ToString(),
                    NoOfDays = empTourPlan.NoOfDays.ToString(),
                    Units = employeeDetails?.units,
                    Lavel = "N1",
                };
                List<TentativeTourPlans> TentativeTourPlans = new List<TentativeTourPlans>();
                var tentivePlans = _dbContext.TentativeTravelPlans.Where(f => f.EmpTourPlanId == empTourPlan.Id).ToList();
                if (tentivePlans != null)
                {
                    foreach (var item in tentivePlans)
                    {
                        TentativeTourPlans _tentativeTourPlan = new TentativeTourPlans()
                        {
                            Date = item.Date.ToString(),
                            From = item.From,
                            To = item.To,
                            TravelMode = item.TravelMode,
                            ClassOfCity = item.ClassOfCity,
                            Remark = item.Remarks
                        };
                        TentativeTourPlans.Add(_tentativeTourPlan);
                    }
                }

                string basePath = "wwwroot/DownloadFolder/";
                if (!Directory.Exists(basePath))
                {
                    Directory.CreateDirectory(basePath);
                }

                string outputZipFilePath = string.Empty;

                if (employeeDetails != null && !string.IsNullOrEmpty(employeeDetails.empName))
                {
                    outputZipFilePath = Path.Combine(basePath, employeeDetails.empName + "_GeneratedFiles.pdf");

                    _pDFGenerator.GeneratePDF(EmployeeDetails, TentativeTourPlans, outputZipFilePath);
                }
                //string outputZipFilePath = Path.Combine(basePath, employeeDetails.empName + "_GeneratedFiles.pdf");
                string urlPDF = string.Empty;

                if (outputZipFilePath != null && !string.IsNullOrEmpty(outputZipFilePath))
                {

                    urlPDF = _pDFGenerator.GenerateDownloadUrl(outputZipFilePath, baseUrl);
                }

                bool IsAdvanceRequired = Convert.ToBoolean(empTourPlan.IsAdvanceRequired);
                int ManagerId = 459;

                List<object> TravelFiles = new List<object>();

                var _uploadTypeDetailsId = _dbContext.UploadTypeDetails.Where(f => f.EmpTourPlanId == empTourPlan.Id && f.UploadTypeId == ((long)RecordMasterUploadDocType.Travel)).Select(s => s.Id).FirstOrDefault();
                var _uploadDocuments = _dbContext.UploadDocuments.Where(f => f.UploadTypeDetailsId == Convert.ToInt32(_uploadTypeDetailsId)).ToList();
                if (_uploadDocuments != null && _uploadDocuments.Count != 0)
                {
                    foreach (var item in _uploadDocuments)
                    {
                        var TravelFile = new { PathUrl = baseUrl + item.PathUrl, item.FileName };
                        TravelFiles.Add(TravelFile);
                    }

                }
                var TravelEstimate = new { empTourPlan.TravelEstimateAmount, TravelFiles };

                _uploadTypeDetailsId = _dbContext.UploadTypeDetails.Where(f => f.EmpTourPlanId == empTourPlan.Id && f.UploadTypeId == ((long)RecordMasterUploadDocType.Accommodation)).Select(s => s.Id).FirstOrDefault();
                _uploadDocuments = _dbContext.UploadDocuments.Where(f => f.UploadTypeDetailsId == Convert.ToInt32(_uploadTypeDetailsId)).ToList();


                List<object> AccommodationFiles = new List<object>();

                if (_uploadDocuments != null && _uploadDocuments.Count != 0)
                {
                    foreach (var item in _uploadDocuments)
                    {
                        var AccommodationFile = new { PathUrl = baseUrl + item.PathUrl, item.FileName };
                        AccommodationFiles.Add(AccommodationFile);
                    }

                }

                var AccommodationEstimate = new { empTourPlan.AccomodationEstimate, AccommodationFiles };
                ApproverDetailsDto approverDetails = null;

                employeeDetails = await _employeeRepository.GetEmployeeDetails(Convert.ToInt32(empTourPlan?.ApprovedBy));
                 if(employeeDetails != null)
                {
                    approverDetails = new ApproverDetailsDto()
                    {
                        ApprovalDate = Convert.ToDateTime(empTourPlan.ApprovedDate).ToString("MM/dd/yyyy HH:mm"),
                        ApprovedAmount = empTourPlan.ApprovedAmount,
                        ApprovedById = empTourPlan.ApprovedBy,
                        ApprovedBy = employeeDetails.empName,
                        FilePath = urlPDF,
                    };
                }   
                
                var AdvanceRequired = empTourPlan.AdvanceRequired;
                var tourDetail = new
                {
                    EmployeeDetails,
                    TentativeTourPlans,
                    IsAdvanceRequired,
                    AdvanceRequired,
                    TravelEstimate,
                    AccommodationEstimate,
                    ManagerId,
                    ApproverDetails = approverDetails,
                   
                };
                responeModel.Data = tourDetail;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                responeModel.Data = null;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.Message = "Record not found.";
            }
            return responeModel;
        }

        /*public class ApproverDetails
        {
            public  string ApprovalDate { get; set; }
            public  double? ApprovedAmount { get; set; }
            public  int? ApprovedById { get; set; }
            public  string ApprovedBy { get; set; }
            public  string FilePath { get; set; }
        }*/

        public Task<ResponeModel> Update(EmpTourPlanDto empTourPlanDetails, int id)
        {
            throw new NotImplementedException();

            // ResponeModel responeModel = new ResponeModel();
            //if (advanceUploadTypeDetails != null && id != 0)
            //{
            //    var advanceupdateType = _dbContext.AdvanceUploadTypeDetails.Where(e => e.Id == id).FirstOrDefault();

            //    if (advanceupdateType != null)
            //    {
            //        advanceupdateType.AdvanceId = advanceUploadTypeDetails.AdvanceId;
            //        advanceupdateType.UploadTypeId = advanceUploadTypeDetails.UploadTypeId;
            //        advanceupdateType.Amount = advanceUploadTypeDetails.Amount;
            //        await _dbContext.SaveChangesAsync();
            //        responeModel.Data = advanceupdateType;
            //        responeModel.StatusCode = System.Net.HttpStatusCode.Created;
            //        responeModel.Error = false;
            //        responeModel.Message = "Advance type Updated Successfully";
            //    }
            //}
            //return responeModel;

            //throw new NotImplementedException();
        }

        public async Task<ResponeModel> EmpTourRequest(EmpTourPlanRequestDto empTourPlanRequestDto)
        {
            ResponeModel responeModel = new ResponeModel();
            if (empTourPlanRequestDto != null)
            {
                IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

                if (empTourPlanRequestDto != null)
                {
                    EmpTourPlan empTourPlan = new EmpTourPlan()
                    {
                        EmpId = empTourPlanRequestDto.EmpId,
                        PurposeOfTour = empTourPlanRequestDto.PurposeOfTour,
                        TypeOfTour = empTourPlanRequestDto.TypeOfTour,
                        Destination = empTourPlanRequestDto.Destination,
                        Source = empTourPlanRequestDto.Source,
                        TantetiveDateOfDeparture = empTourPlanRequestDto.TantetiveDateOfDeparture,
                        NoOfDays = empTourPlanRequestDto.NoOfDays,
                        IsRoad = empTourPlanRequestDto.IsRoad,
                        IsRail = empTourPlanRequestDto.IsRail,
                        IsAir = empTourPlanRequestDto.IsAir,
                        ClassOfCity = empTourPlanRequestDto.ClassOfCity,
                        Grade = empTourPlanRequestDto.Grade,
                        TravelEstimateAmount = empTourPlanRequestDto?.TourTravelEstimate?.EstimatedAmount,
                        AccomodationEstimate = empTourPlanRequestDto?.TourAccommodationEstimate?.EstimatedAmount,
                        AdvanceRequired = empTourPlanRequestDto?.AdvanceRequired,
                        // ApprovedAmount = empTourPlanRequestDto.ApprovedAmount,
                        IsX = empTourPlanRequestDto?.IsX,
                        IsY = empTourPlanRequestDto?.IsY,
                        IsZ = empTourPlanRequestDto?.IsZ,
                        // ApprovedBy = empTourPlanRequestDto.ApprovedBy,
                        PaidAmount = empTourPlanRequestDto?.PaidAmount,
                        // PaymentReferenceNo = empTourPlanRequestDto.PaymentReferenceNo,
                        IsDirectClaim = empTourPlanRequestDto?.IsDirectClaim,
                        IsAdvanceRequired = empTourPlanRequestDto?.IsAdvanceRequired,
                        CreatedBy = empTourPlanRequestDto.EmpId,
                        CreatedDate = DateTime.Now,


                    };
                    _dbContext.Add(empTourPlan);
                    _dbContext.SaveChanges();

                    var jsonString = JsonConvert.DeserializeObject(empTourPlanRequestDto.TentativeTravelPlans);

                    var tentativeTravelPlan = JsonConvert.DeserializeObject<List<TentativeTravelPlan>>(jsonString.ToString());

                    List<TentativeTravelPlan> tentativeTravelPlans = new List<TentativeTravelPlan>();
                    if (tentativeTravelPlan != null)
                    {
                        foreach (var item in tentativeTravelPlan)
                        {
                            TentativeTravelPlan tentativeTravelPlanSingle = new();
                            {
                                tentativeTravelPlanSingle.EmpTourPlanId = empTourPlan.Id;
                                tentativeTravelPlanSingle.Date = item.Date;
                                tentativeTravelPlanSingle.From = item.From;
                                tentativeTravelPlanSingle.To = item.To;
                                tentativeTravelPlanSingle.TravelMode = item.TravelMode;
                                tentativeTravelPlanSingle.TourDetails = item.TourDetails;
                                tentativeTravelPlanSingle.ClassOfCity = item.ClassOfCity;
                                tentativeTravelPlanSingle.Remarks = item.Remarks;
                            }
                            tentativeTravelPlans.Add(tentativeTravelPlanSingle);
                        }
                    }
                    _dbContext.AddRange(tentativeTravelPlans);
                    await _dbContext.SaveChangesAsync();


                    if (empTourPlanRequestDto.TourTravelEstimate != null)
                    {
                        var UploadDocuments = await UploadBillFiles(empTourPlanRequestDto.TourTravelEstimate.TravelFiles, "TourTravelEstimate");

                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                EmpTourPlanId = empTourPlan.Id,
                                UploadTypeId = ((long)RecordMasterUploadDocType.Travel),
                                Amount = 101,
                                CreatedBy = empTourPlanRequestDto.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.UploadTypeDetailsId == null || e.UploadTypeDetailsId == 0).Select(s => { s.UploadTypeDetailsId = uploadTypeDetail.Id; s.CreatedBy = 1; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }

                    }
                    if (empTourPlanRequestDto.TourAccommodationEstimate != null)
                    {
                        var UploadDocuments = await UploadBillFiles(empTourPlanRequestDto.TourAccommodationEstimate.AccommodationFiles, "TourAccommodationEstimate");

                        if (UploadDocuments != null && UploadDocuments.Count != 0)
                        {
                            UploadTypeDetail uploadTypeDetail = new UploadTypeDetail()
                            {
                                EmpTourPlanId = empTourPlan.Id,
                                UploadTypeId = ((long)RecordMasterUploadDocType.Accommodation),
                                Amount = 101,
                                CreatedBy = empTourPlanRequestDto.EmpId,
                                CreatedDate = DateTime.Now
                            };

                            _dbContext.Add(uploadTypeDetail);
                            await _dbContext.SaveChangesAsync();

                            UploadDocuments = UploadDocuments.Where(e => e.UploadTypeDetailsId == null || e.UploadTypeDetailsId == 0).Select(s => { s.UploadTypeDetailsId = uploadTypeDetail.Id; s.CreatedBy = 1; s.CreatedDate = DateTime.Now; s.IsActive = true; s.Comment = ""; return s; }).ToList();

                            await _dbContext.AddRangeAsync(UploadDocuments);
                            await _dbContext.SaveChangesAsync();
                        }

                    }


                    EMPClaimProcessDetail empClaimProcessDetails = new EMPClaimProcessDetail()
                    {
                        EmpTourId = empTourPlan.Id,
                        ClaimTypeId = ((long)RecordMasterClaimTypes.Advance),
                        StatusId = ((long)RecordMasterClaimStatusCategory.PendingApproval),
                        SenderId = empTourPlanRequestDto.EmpId,
                        RecipientId = empTourPlanRequestDto.ManagerId,
                        CreatedBy = empTourPlanRequestDto.EmpId,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                    };

                    await _dbContext.AddAsync(empClaimProcessDetails);
                    await _dbContext.SaveChangesAsync();

                    transaction.Commit();

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
            }
            return responeModel;
        }

        private async Task<List<UploadDocument>> UploadBillFiles(List<IFormFile> files, string floderName)
        {
            bool status = false;
            var response = await _commandRepo.UploadDocumets(files, floderName);
            List<UploadDocument> uploadDocuments = new List<UploadDocument>();
            if (response != null && response.Count != 0)
            {
                foreach (var item in response)
                {
                    UploadDocument uploadDocument = new UploadDocument()
                    {
                        FileName = item.fileName,
                        PathUrl = item.filePath
                    };

                    uploadDocuments.Add(uploadDocument);
                }

            }
            return uploadDocuments;
        }

        public async Task<ResponeModel> GetGradeData(string level)
        {
            ResponeModel responeModel = new ResponeModel();
            var gradeDetail = await _dbContext.GradeDetails.Where(e => level == null ? e.Lavel == e.Lavel : e.Lavel == level && e.IsActive == true).ToListAsync();
            List<GradeDetailDto> gradeDetailDto = new List<GradeDetailDto>();
            GradeDetailDto gradeDetailDto1 = new GradeDetailDto();
            foreach (var grade in gradeDetail)
            {
                gradeDetailDto1.Lavel = grade.Lavel;
                gradeDetailDto1.X = grade.X;
                gradeDetailDto1.Y = grade.Y;
                gradeDetailDto1.Z = grade.Z;
            }
            gradeDetailDto.Add(gradeDetailDto1);


            //gradeDetailDto.Lavel =gradeDetail
            responeModel.Data = gradeDetailDto;
            responeModel.DataLength = gradeDetail.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = gradeDetail.Count + " Grade data found ";
            return responeModel;
        }

        public async Task<ResponeModel> EmpTourApprovedAmount(EmpTourApprovedDto empTourApprovedDto, int id)
        {
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            ResponeModel responeModel = new ResponeModel();
            if (empTourApprovedDto != null && id != 0)
            {
                var employeeTourApproved = _dbContext.EmpTourPlans.Where(e => e.Id == id).FirstOrDefault();

                if (employeeTourApproved != null)
                {
                    employeeTourApproved.ApprovedDate = empTourApprovedDto.ApprovalDate;
                    employeeTourApproved.ApprovedAmount = empTourApprovedDto.ApprovedAmount;
                    employeeTourApproved.ApprovedBy = empTourApprovedDto.ApprovedById;
                    employeeTourApproved.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeeTourApproved;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Employee tour advance amount approved";
                }

            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback
            return responeModel;
        }
    }
}
