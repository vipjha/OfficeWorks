using HealthClaim.Utility.Eumus;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL;
using TourProgram.DAL.Models;
using TourProgram.Model.Dtos.Employee;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Concrete
{
    public class TourListingRepository : GenricRepository<EmpTourPlan>, ITourListingRepository
    {
        private readonly TourProgramDbContext _dbContext;
        private readonly IEmployeeRepository _employeeRepository;

        public TourListingRepository(TourProgramDbContext db, IEmployeeRepository employeeRepository) : base(db)
        {
            _dbContext = db;
            _employeeRepository = employeeRepository;
        }
        public async Task<ResponeModel> GetTourPlanList(int recipientId)
        {
            ResponeModel responeModel = new ResponeModel();
            var query = from emTP in _dbContext.EmpTourPlans
                        join ecpd in _dbContext.EMPClaimProcessDetails on emTP.Id equals ecpd.EmpTourId
                        join claimType in _dbContext.ClaimTypes on ecpd.ClaimTypeId equals claimType.Id
                        where ecpd.RecipientId == (
                            from e in _dbContext.EMPClaimProcessDetails
                            where e.EmpTourId == emTP.Id
                            orderby e.Id descending
                            select e.RecipientId
                        ).FirstOrDefault() && ecpd.ClaimTypeId == (
                            from e in _dbContext.EMPClaimProcessDetails
                            where e.EmpTourId == emTP.Id
                            orderby e.Id descending
                            select e.ClaimTypeId
                        ).FirstOrDefault()
                        select new
                        {
                            tourId = emTP.Id,
                            empId = emTP.EmpId,
                            RequestDate = emTP.CreatedDate,
                            PurposeofTour = emTP.PurposeOfTour,
                            TourStartDate = emTP.TantetiveDateOfDeparture,
                            Source = emTP.Source,
                            Destination = emTP.Destination,
                            TotalDays = emTP.NoOfDays,
                            SenderId = (
                                from e in _dbContext.EMPClaimProcessDetails
                                where e.EmpTourId == emTP.Id
                                orderby e.Id descending
                                select e.SenderId
                            ).FirstOrDefault(),
                            RecipientId = ecpd.RecipientId,
                            ClaimTypeId = (
                                from e in _dbContext.EMPClaimProcessDetails
                                where e.EmpTourId == emTP.Id
                                orderby e.Id descending
                                select e.ClaimTypeId
                            ).FirstOrDefault(),

                            ClaimType = (
                                from ct in _dbContext.ClaimTypes
                                where ct.Id == (
                                    from e in _dbContext.EMPClaimProcessDetails
                                    where e.EmpTourId == emTP.Id
                                    orderby e.Id descending
                                    select e.ClaimTypeId
                                ).FirstOrDefault()
                                select ct.Name
                            ).FirstOrDefault(),


                            Status = (
                                from cs in _dbContext.ClaimStatusCategorys
                                where cs.Id == (
                                    from e in _dbContext.EMPClaimProcessDetails
                                    where e.EmpTourId == emTP.Id
                                    orderby e.Id descending
                                    select e.StatusId
                                ).FirstOrDefault()
                                select cs.Name
                            ).FirstOrDefault(),

                            StatusId = (
                                from e in _dbContext.EMPClaimProcessDetails
                                where e.EmpTourId == emTP.Id
                                orderby e.Id descending
                                select e.StatusId
                            ).FirstOrDefault()
                        };

            var result = query.ToList();
            var tourData = query.ToList().Where(f => f.RecipientId == recipientId && (f.StatusId == ((long)RecordMasterClaimStatusCategory.FinanceProcessing) || f.StatusId == ((long)RecordMasterClaimStatusCategory.PendingApproval)));

            List<object> tourRequestList = new();
            if (tourData != null && tourData.Count() != 0)
            {
                foreach (var item in tourData)
                {
                    EmployeeDetails employeeDetails = null;
                    employeeDetails = await _employeeRepository.GetEmployeeDetails(item.empId);
                    var tourRequest = new
                    {
                        tourId = item.tourId,
                        tourType = item.ClaimType,
                        employeeDetails?.empId,
                        employeeDetails?.empName,
                        employeeDetails?.designation,
                        RequestDate = item.RequestDate,
                        PurposeofTour = item.PurposeofTour,
                        TourStartDate = item.TourStartDate,
                        Source = item.Source,
                        Destination = item.Destination,
                        TotalDays = item.TotalDays,
                        Status = item.Status
                    };
                    tourRequestList.Add(tourRequest);
                }
                responeModel.Data = tourRequestList;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.DataLength = tourRequestList.Count;
            }
            else
            {
                responeModel.Data = tourRequestList;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.DataLength = tourRequestList.Count;
            }
            return responeModel;
        }

        public async Task<ResponeModel> GetTourRequest(int empId)
        {
            ResponeModel responeModel = new ResponeModel();
            var query = from emTP in _dbContext.EmpTourPlans
                        join ecpd in _dbContext.EMPClaimProcessDetails on emTP.Id equals ecpd.EmpTourId
                        join claimType in _dbContext.ClaimTypes on ecpd.ClaimTypeId equals claimType.Id
                        where ecpd.RecipientId == (
                            from e in _dbContext.EMPClaimProcessDetails
                            where e.EmpTourId == emTP.Id
                            orderby e.Id descending
                            select e.RecipientId
                        ).FirstOrDefault() && ecpd.ClaimTypeId == (
                            from e in _dbContext.EMPClaimProcessDetails
                            where e.EmpTourId == emTP.Id
                            orderby e.Id descending
                            select e.ClaimTypeId
                        ).FirstOrDefault()
                        select new
                        {
                            tourId = emTP.Id,
                            RequestDate = emTP.CreatedDate,
                            PurposeofTour = emTP.PurposeOfTour,
                            TourStartDate = emTP.TantetiveDateOfDeparture,
                            Source = emTP.Source,
                            Destination = emTP.Destination,
                            TotalDays = emTP.NoOfDays,
                            SenderId = (
                                from e in _dbContext.EMPClaimProcessDetails
                                where e.EmpTourId == emTP.Id
                                orderby e.Id descending
                                select e.SenderId
                            ).FirstOrDefault(),
                            RecipientId = ecpd.RecipientId,
                            ClaimTypeId = (
                                from e in _dbContext.EMPClaimProcessDetails
                                where e.EmpTourId == emTP.Id
                                orderby e.Id descending
                                select e.ClaimTypeId
                            ).FirstOrDefault(),

                            ClaimType = (
                                from ct in _dbContext.ClaimTypes
                                where ct.Id == (
                                    from e in _dbContext.EMPClaimProcessDetails
                                    where e.EmpTourId == emTP.Id
                                    orderby e.Id descending
                                    select e.ClaimTypeId
                                ).FirstOrDefault()
                                select ct.Name
                            ).FirstOrDefault(),



                            Status = (
                                from cs in _dbContext.ClaimStatusCategorys
                                where cs.Id == (
                                    from e in _dbContext.EMPClaimProcessDetails
                                    where e.EmpTourId == emTP.Id
                                    orderby e.Id descending
                                    select e.StatusId
                                ).FirstOrDefault()
                                select cs.Name
                            ).FirstOrDefault(),
                            StatusId = (
                                from e in _dbContext.EMPClaimProcessDetails
                                where e.EmpTourId == emTP.Id
                                orderby e.Id descending
                                select e.StatusId
                            ).FirstOrDefault()
                        };

            var result = query.ToList();
            var tourData = query.ToList().Where(f => f.SenderId == empId && (f.StatusId == ((long)RecordMasterClaimStatusCategory.Approved) || f.StatusId == (long)RecordMasterClaimStatusCategory.PendingApproval) || f.StatusId == (long)RecordMasterClaimStatusCategory.Rejected);

            List<object> tourRequestList = new();
            if (tourData != null && tourData.Count() != 0)
            {
                foreach (var item in tourData)
                {
                    EmployeeDetails employeeDetails = null;
                    employeeDetails = await _employeeRepository.GetEmployeeDetails(empId);
                    var tourRequest = new
                    {
                        tourId = item.tourId,
                        tourType = item.ClaimType,
                        employeeDetails?.empId,
                        employeeDetails?.empName,
                        employeeDetails?.designation,
                        RequestDate = item.RequestDate,
                        PurposeofTour = item.PurposeofTour,
                        TourStartDate = item.TourStartDate,
                        Source = item.Source,
                        Destination = item.Destination,
                        TotalDays = item.TotalDays,
                        Status = item.Status
                    };
                    tourRequestList.Add(tourRequest);
                }
                responeModel.Data = tourRequestList;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.DataLength = tourRequestList.Count;
            }
            else
            {
                responeModel.Data = tourRequestList;
                responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
                responeModel.DataLength = tourRequestList.Count;
            }
            return responeModel;
        }
    }
}
