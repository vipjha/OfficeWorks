using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Response;
using HealthClaim.Utility.Eumus;
using HealthClaim.Utility.Resources;
using Microsoft.EntityFrameworkCore.Storage;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class EmployeeRepository : GenricRepository<Employee>, IEmployeeRepository
    {
        private HealthClaimDbContext _dbContext;
        #region Constructor
        /// <summary>
        /// This is constructor to set dependency injection
        /// </summary>
        /// <param name="db"></param>
        public EmployeeRepository(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        }
        #endregion

        private async Task<bool> CreateSelfMember(EmpFamily empFamily)
        {
            await _dbContext.AddAsync(empFamily);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        private async Task<bool> CreateEmpProfiles(EmpProfile empProfile)
        {
            await _dbContext.AddAsync(empProfile);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        #region Create Employee
        /// <summary>
        /// This method is used for add new employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Create(EmployeeModel employeeModel)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (employeeModel != null)
            {
                Employee employee;


                employee = new Employee()
                {
                    EmpId = employeeModel.EmpId,
                    Name = employeeModel.Name,
                    DateofBirth = employeeModel.DateofBirth,
                    JoiningDate = employeeModel.JoiningDate,
                    //PhotoFileName = employeeModel.PhotoFileName,
                    //PhotoPath = employeeModel.PhotoPath,
                    BloodGroup = employeeModel.BloodGroup,
                    EmailId = employeeModel.EmailId,
                    Designation = employeeModel.Designation,
                    Mobile = employeeModel.Mobile,
                    Gender = employeeModel.Gender,
                    IsActive = true,
                    CreatedBy = employeeModel.CreatedBy,
                    CreatedDate = DateTime.Now,
                    //UpdatedBy = employeeModel.UpdatedBy,
                    //UpdatedDate=DateTime.Now,
                };
                _dbContext.Add(employee);
                int id = await _dbContext.SaveChangesAsync();
                EmpFamily empFamily = new EmpFamily()
                {
                    EmpId = employee.Id,
                    Name = employee.Name,
                    RelationId = 7,// 7 Id for Self Member
                    IsActive = true,
                    CreatedBy = employee.Id,
                    CreatedDate = DateTime.Now,
                    Gender = employeeModel.Gender,
                    MobileNo = employee.Mobile,
                    EmailId = employee.EmailId,
                    DateOfBirth = Convert.ToDateTime(employee.DateofBirth),
                    BloodGroup = employeeModel.BloodGroup,
                };

                await CreateSelfMember(empFamily);

                EmpProfile empProfile = new EmpProfile()
                {
                    EmpId = employee.Id,
                    Location = employeeModel.Location,
                    EmpLavel = employeeModel.EmpLavel,
                    Designation = employeeModel.Designation,
                    IsPrimary = employeeModel.IsPrimary,
                    OrgPrimaryName = employeeModel.OrgPrimaryName,
                    OrgUnitName = employeeModel.OrgUnitName,
                    PostAssignedInOrgUnit = employeeModel.PostAssignedInOrgUnit,
                    ApplicabelDate = employeeModel.ApplicabelDate,
                    PostAssignedInWrapperName = employeeModel.PostAssignedInWrapperName,
                    MarkingAbbr = employeeModel.MarkingAbbr,
                    PostNameEn = employeeModel.PostNameEn,
                    WrapperName = employeeModel.WrapperName,
                    Department = employeeModel.Department,
                    ReportingOfficerId = employeeModel.ReportingOfficerId,
                    CreatedBy = employeeModel.CreatedBy,
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                };

                await CreateEmpProfiles(empProfile);

                responeModel.Data = employee;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = CommonMessage.CreateMessage;

            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback
            return responeModel;
        }
        #endregion



        #region Create Employee Relation
        /// <summary>
        /// This method is used for create employee relation
        /// </summary>
        /// <param name="empRelationModel"></param>
        /// <returns></returns>
        public async Task<ResponeModel> CreateEmpRelation(EmpRelationModel empRelationModel)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (empRelationModel != null)
            {
                EmpRelation employeerelation = new EmpRelation()
                {
                    Name = empRelationModel.Name,
                    Description = empRelationModel.Description,
                    CreatedDate = DateTime.Now,

                };
                _dbContext.Add(employeerelation);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = employeerelation;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = CommonMessage.CreateMessage;

            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback

            return responeModel;
        }

        #endregion
        #region Delete
        /// <summary>
        /// This method is used for delete record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Delete(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

            if (id != 0)
            {
                var employeeDetails = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Employee deleted successfully.";

                }
            }

            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback

            return responeModel;
        }

        #endregion
        #region Delete Employee Relation
        /// <summary>
        /// This method is used for Delete Employee relation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> DeleteEmpRelation(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var employeeDetails = _dbContext.EmpRelations.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Employee relation deleted successfully.";

                }
            }
            return responeModel;
        }

        #endregion
        #region Get Employee
        /// <summary>
        /// This method is used for fetch the employee details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

            var employees = _dbContext.Employees.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToList();
            responeModel.Data = employees;
            responeModel.DataLength = employees.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = employees.Count + " Employee found.";

            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback

            return responeModel;
        }
        #endregion
        public async Task<ResponeModel> GetEmpRelation(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var employees = _dbContext.EmpRelations.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToList();
            responeModel.Data = employees;
            responeModel.DataLength = employees.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = employees.Count + " Employee relation found.";

            return responeModel;
        }

        #region Update Employee Details
        /// <summary>
        /// This method is used for update employee details
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Update(EmployeeModel employeeModel, int id)
        {

            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();
            if (employeeModel != null && id != 0)
            {
                var employeeDetails = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.EmpId = employeeModel.EmpId;
                    employeeDetails.BloodGroup = employeeModel.BloodGroup;
                    employeeDetails.EmailId = employeeModel.EmailId;
                    employeeDetails.Designation = employeeModel.Designation;
                    employeeDetails.Mobile = employeeModel.Mobile;
                    //employeeDetails.IsActive = employeeModel.IsActive;
                    employeeDetails.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeeDetails;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Employee updated successfully.";

                }

            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback

            return responeModel;
        }

        #endregion
        #region Update Employee Relation
        /// <summary>
        /// This method is used for update Employee relation
        /// </summary>
        /// <param name="empRelationModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> UpdateEmpRelation(EmpRelationModel empRelationModel, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            IDbContextTransaction transaction = _dbContext.Database.BeginTransaction();

            if (empRelationModel != null && id != 0)
            {
                var employeeDetails = _dbContext.EmpRelations.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.Name = empRelationModel.Name;
                    employeeDetails.Description = empRelationModel.Description;

                    employeeDetails.IsActive = empRelationModel.IsActive;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeeDetails;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Employee relation updated successfully.";

                }

            }
            await transaction.CommitAsync(); // Commit the transaction, if any exception will occered this line will not be executed, so here is no need to rollback

            return responeModel;
        }

        public async Task<ResponeModel> GetEmployeeProfile(int EmpId)
        {
            ResponeModel responeModel = new ResponeModel();
            var query = from claims in _dbContext.EmployeeClaims
                        join ecs in _dbContext.EmpClaimStatus on claims.Id equals ecs.ClaimId
                        join empAdv in _dbContext.EmpAdvances on claims.Id equals empAdv.ClaimId
                        join topUp in _dbContext.EmpAdvanceTopUp on empAdv.Id equals topUp.EmpAdvanceId into topUpGroup
                        from topUp in topUpGroup.DefaultIfEmpty()
                        where empAdv.EmplId == EmpId
                        select new
                        {
                            AdvanceAmount = ecs.ClaimTypeId == 1 ? empAdv.AdvanceAmount
                                         : ecs.ClaimTypeId == 4 ? topUp.TopRequiredAmount
                                         : ecs.ClaimTypeId == 2 || ecs.ClaimTypeId == 3 ? claims.ClaimAmount : 0,
                            ApprovedAmount = ecs.ClaimTypeId == 1 ? empAdv.ApprovedAmount
                                           : ecs.ClaimTypeId == 4 ? topUp.TopApprovedAmount
                                           : ecs.ClaimTypeId == 2 || ecs.ClaimTypeId == 3 ? claims.ClaimApprovedAmount : 0,
                            ecs.ClaimTypeId,
                            ecs.StatusId,
                            ecs.ClaimId
                        };


            var data = query.ToList();
            int totalNumberofApproved = 0;
            int totalAdvancePay = 0;
            int totalClaimPay = 0;
            int totalLimit = 0;
            int totalRequestAmount = 0;
            int totalApprovedAmount = 0;

            var totalApprovedClaims = (from ecs in _dbContext.EmpClaimStatus
                                       join empAdv in _dbContext.EmpAdvances on ecs.ClaimId equals empAdv.ClaimId
                                       where empAdv.EmplId == EmpId && ecs.StatusId == ((long)RecordMasterClaimStatusCategory.Approved)
                                       select ecs).GroupBy(g => g.ClaimId).Count();


            var totalLimitEmp = (from emp in _dbContext.Employees
                                 join ep in _dbContext.EmpProfiles on emp.Id equals ep.EmpId
                                 join org in _dbContext.OrgClaimLimits on ep.EmpLavel equals org.Lavel
                                 where emp.Id == EmpId
                                 select org.Limit).FirstOrDefault();

            totalNumberofApproved = totalApprovedClaims;
            totalLimit = totalLimitEmp;


            foreach (var item in data)
            {
                if ((item.StatusId == ((long)RecordMasterClaimStatusCategory.Approved)) && ((item.ClaimTypeId == ((long)RecordMasterClaimTypes.Advance)) || item.ClaimTypeId == ((long)RecordMasterClaimTypes.TopUpAmount)))
                {
                    totalAdvancePay = Convert.ToInt32(totalAdvancePay + item.ApprovedAmount);
                }

                if ((item.StatusId == ((long)RecordMasterClaimStatusCategory.Approved)) && ((item.ClaimTypeId == ((long)RecordMasterClaimTypes.DirectClaim)) || item.ClaimTypeId == ((long)RecordMasterClaimTypes.AdvanceClaim)))
                {
                    totalClaimPay = Convert.ToInt32(totalClaimPay + item.ApprovedAmount);
                }

                if (item.StatusId == ((long)RecordMasterClaimStatusCategory.Approved))
                {
                    totalApprovedAmount = Convert.ToInt32(totalApprovedAmount + item.ApprovedAmount);
                }
                totalRequestAmount = Convert.ToInt32(totalRequestAmount + item.AdvanceAmount);
            }

            var empProfile = new
            {
                TotalNumberofApproved = totalNumberofApproved,
                AdvancePay = totalAdvancePay,
                ClaimPay = totalClaimPay,
                TotalLimit = totalLimit,
                TotalRequestAmount = totalRequestAmount,
                TotalApprovedAmount = totalApprovedAmount
            };

            responeModel.Data = empProfile;
            responeModel.DataLength = 0;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = "Profile record fetch sucessfully.";
            return responeModel;
        }

        public async Task<ResponeModel> GetEmpAboutMe(long id)
        {
            ResponeModel responeModel = new ResponeModel();
            // Helper method to calculate age from a date of birth

            var targetEmpId = id; // Set the target employee ID

            var query = (from es in _dbContext.Employees
                         join emp in _dbContext.EmpProfiles on es.Id equals emp.EmpId
                         where emp.EmpId == targetEmpId
                         select new
                         {
                             EmployeeId = es.Id,
                             DateOfJoining = Convert.ToDateTime(es.JoiningDate).ToString("MM/dd/yyyy"),
                             DateOfBirth = Convert.ToDateTime(es.DateofBirth).ToString("MM/dd/yyyy"),
                             EmployeeName = es.Name,
                             EmailId = es.EmailId,
                             Mobile = es.Mobile,
                             Gender = es.Gender,
                             Age = Convert.ToDateTime(es.DateofBirth).ToString("MM/dd/yyyy")
                         }).FirstOrDefault();


            if (query != null)
            {
                responeModel.Data = query;
                responeModel.DataLength = 1;
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                responeModel.Error = false;
                responeModel.Message = "Employee records found.";

                return responeModel;
            }

            responeModel.DataLength = 0;
            responeModel.StatusCode = System.Net.HttpStatusCode.NotFound;
            responeModel.Error = true;
            responeModel.Message = "No Employee records found.";
            return responeModel;
        }
        #endregion


        public async Task<ResponeModel> GetEmployeeListOnBaseOfRole(string roleId)
        {
            ResponeModel responeModel = new ResponeModel();

            var query = (from em in _dbContext.Employees
                         join ep in _dbContext.EmpProfiles on em.Id equals ep.EmpId
                         join ar in _dbContext.Roles on ep.RoleId equals ar.Id
                         where ar.Id == roleId
                         select new
                         {
                             EmployeeName = em.Name,
                             EmployeeRole = ar.Name,
                             EmployeeId = ep.EmpId
                         }).ToList();
            responeModel.Data = query;
            responeModel.DataLength = query.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = query.Count + "Employee are found.";
            return responeModel;
        }
    }
}

