using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL;
using TourProgram.DAL.Models;
using TourProgram.Model.Dtos.Employee;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Concrete
{
    public class BulkApprovalRepository : GenricRepository<EmpTourPlan>, IBulkApprovalRepository
    {
        private readonly TourProgramDbContext _dbContext;
        private readonly IEmployeeRepository _employeeRepository;

        public BulkApprovalRepository(TourProgramDbContext db, IEmployeeRepository employeeRepository) : base(db)
        {
            _dbContext = db;
            _employeeRepository = employeeRepository;
        }

        public async Task<ResponeModel> GetAdvanceApproval(int empId)
        {
            ResponeModel responeModel = new ResponeModel()
            {
                Data = null,
                StatusCode = System.Net.HttpStatusCode.NotFound,
                DataLength = 0,
                Message = "Record not found.",
            };

            var query = from etp in _dbContext.EmpTourPlans
                        join fd in _dbContext.FinanceDetails on etp.Id equals fd.EmpTourPlanId
                        join ct in _dbContext.ClaimTypes on fd.ClaimTypeId equals ct.Id
                        // Add your WHERE conditions here
                        // where etp.SomeColumn == "SomeValue"
                        where fd.CreatedBy == empId
                        select new
                        {
                            FinanceDetailsId = fd.Id,
                            TourId = etp.Id,
                            EmpId = etp.EmpId,
                            TourType = ct.Name,
                            SapReferenceNoPaymentApproval = fd.SapReferenceNoPaymentApproval,
                            SapReferenceDatePaymentApproval = fd.SapReferenceDatePaymentApproval,
                            SapReferenceNoPaymentProcessing = fd.SapReferenceNoPaymentProcessing,
                            SapReferenceDatePaymentProcessing = fd.SapReferenceDatePaymentProcessing,
                            ApprovedAmount = fd.ApprovedAmount,
                            AdvanceRequired = etp.AdvanceRequired,
                            PaidAmount = fd.PaidAmount,
                            UTRNO = fd.UTRNO,
                            UTRProcessDate = fd.UTRProcessDate,
                            CreatedBy = fd.CreatedBy,
                            CreatedDate = fd.CreatedDate,
                            SapReferenceDateLiquidation = fd.SapReferenceDateLiquidation,
                            LiquidationAmount = fd.LiquidationAmount,
                            IsLiquidation = fd.IsLiquidation,
                            SapReferenceNoLiquidation = fd.SapReferenceNoLiquidation
                        };

            // To execute the query and get the results
            var empTourPlans = query.OrderByDescending(d=>d.FinanceDetailsId).ToList();



            if (empTourPlans != null && empTourPlans.Count != 0)
            {
                List<object> lstToursAdvances = new();
                foreach (var item in empTourPlans)
                {
                    EmployeeDetails employeeDetails = null;
                    employeeDetails = await _employeeRepository.GetEmployeeDetails(item.EmpId);
                    var tourAdvance = new
                    {
                        Id = item.TourId,
                        EmployeeId = employeeDetails?.empId,
                        EmployeeCode = employeeDetails?.empCode,
                        EmpoyeeName = employeeDetails?.empName,
                        RequestedAmount = item.AdvanceRequired,
                        ApprovedAmount = item.ApprovedAmount,
                        ApprovedDate = Convert.ToDateTime(item.CreatedDate).ToString("MM/dd/yyyy H:mm"),
                        SAPReference = item.SapReferenceNoPaymentApproval,
                        SAPDate = item.SapReferenceDatePaymentApproval,

                    };
                    lstToursAdvances.Add(tourAdvance);
                }
                responeModel.Data = lstToursAdvances;
                responeModel.DataLength = lstToursAdvances.Count;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Message = "Approved amount details";
            }
            return responeModel;
        }

        public async Task<ResponeModel> GetAdvanceBankingApproval(int empId)
        {
            ResponeModel responeModel = new ResponeModel()
            {
                Data = null,
                StatusCode = System.Net.HttpStatusCode.NotFound,
                DataLength = 0,
                Message = "Record not found.",
            };

            var query = from etp in _dbContext.EmpTourPlans
                        join fd in _dbContext.FinanceDetails on etp.Id equals fd.EmpTourPlanId
                        join ct in _dbContext.ClaimTypes on fd.ClaimTypeId equals ct.Id
                        // Add your WHERE conditions here
                        // where etp.SomeColumn == "SomeValue"
                        where fd.CreatedBy == empId
                        select new
                        {
                            FinanceDetailsId = fd.Id,
                            TourId = etp.Id,
                            EmpId = etp.EmpId,
                            TourType = ct.Name,
                            SapReferenceNoPaymentApproval = fd.SapReferenceNoPaymentApproval,
                            SapReferenceDatePaymentApproval = fd.SapReferenceDatePaymentApproval,
                            SapReferenceNoPaymentProcessing = fd.SapReferenceNoPaymentProcessing,
                            SapReferenceDatePaymentProcessing = fd.SapReferenceDatePaymentProcessing,
                            ApprovedAmount = fd.ApprovedAmount,
                            AdvanceRequired = etp.AdvanceRequired,
                            PaidAmount = fd.PaidAmount,
                            UTRNO = fd.UTRNO,
                            UTRProcessDate = fd.UTRProcessDate,
                            CreatedBy = fd.CreatedBy,
                            CreatedDate = fd.CreatedDate,
                            SapReferenceDateLiquidation = fd.SapReferenceDateLiquidation,
                            LiquidationAmount = fd.LiquidationAmount,
                            IsLiquidation = fd.IsLiquidation,
                            SapReferenceNoLiquidation = fd.SapReferenceNoLiquidation
                        };

            // To execute the query and get the results
            var empTourPlans = query.ToList().Where(f => f.SapReferenceNoPaymentApproval != null && f.SapReferenceDatePaymentApproval!=null).OrderByDescending(d=>d.FinanceDetailsId).ToList();



            if (empTourPlans != null && empTourPlans.Count != 0)
            {
                List<object> lstToursAdvances = new();
                foreach (var item in empTourPlans)
                {
                    EmployeeDetails employeeDetails = null;
                    employeeDetails = await _employeeRepository.GetEmployeeDetails(item.EmpId);
                    var tourAdvance = new
                    {
                        Id = item.TourId,
                        EmployeeId = employeeDetails?.empId,
                        EmployeeCode = employeeDetails?.empCode,
                        EmpoyeeName = employeeDetails?.empName,
                        RequestedAmount = item.AdvanceRequired,
                        ApprovedAmount = item.ApprovedAmount,
                        ApprovedDate = Convert.ToDateTime(item.CreatedDate).ToString("MM/dd/yyyy H:mm"),
                        SAPApprovalReference = item?.SapReferenceNoPaymentApproval,
                        SAPApprovalDate = item?.SapReferenceDatePaymentApproval,
                        SAPReference = item?.SapReferenceNoPaymentProcessing,
                        SAPDate = item?.SapReferenceDatePaymentProcessing,

                    };
                    lstToursAdvances.Add(tourAdvance);
                }
                responeModel.Data = lstToursAdvances;
                responeModel.DataLength = lstToursAdvances.Count;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Message = "Approved amount details";
            }
            return responeModel;
        }
    }
}
