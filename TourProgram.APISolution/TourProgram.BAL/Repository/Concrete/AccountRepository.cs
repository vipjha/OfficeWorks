using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Office.Word;
using HealthClaim.BAL.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL;
using TourProgram.DAL.Models;
using TourProgram.Model.Dtos.Employee;
using TourProgram.Model.Dtos.Notification;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.UsersDtos;

namespace TourProgram.BAL.Repository.Concrete
{
    public class AccountRepository : GenricRepository<ApplicationUser>, IAccountRepository
    {
        private readonly TourProgramDbContext _dbContext;

        public readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _signInManager;
        public readonly TokenService _tokenService;
        private readonly IEmployeeRepository _employeeRepository;
        private INotificationRepository _iNotificationRepository;

        public AccountRepository(TourProgramDbContext db, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, TokenService tokenService, IEmployeeRepository employeeRepository, INotificationRepository notificationRepository) : base(db)
        {
            _dbContext = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _employeeRepository = employeeRepository;
            _iNotificationRepository = notificationRepository;
        }

        //public async Task<ResponeModel> AccountCreate(RegisterDto registerDto)
        //{
        //    //throw new NotImplementedException();

        //    ResponeModel responeModel = new ResponeModel();
        //    if ((await _userManager.Users.AnyAsync(x => x.Email == registerDto.UserName)) || (await _userManager.Users.AnyAsync(x => x.UserName == registerDto.UserName)))
        //    {
        //        responeModel.Message = registerDto.UserName + " Email taken.";
        //        responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
        //        return responeModel;
        //    }
        //    var employee = _dbContext.Employees.Where(e => e.Id == registerDto.EmpId).FirstOrDefault();
        //    string empEmail = string.Empty;
        //    string empMobile = string.Empty;
        //    if (employee != null)
        //    {
        //        empEmail = employee.EmailId;
        //        empMobile = employee.Mobile;
        //    }
        //    var user = new ApplicationUser
        //    {
        //        Email = empEmail,
        //        UserName = registerDto.UserName,
        //        EmpId = registerDto.EmpId,
        //        PhoneNumber = empMobile,
        //    };
        //    await _userManager.AddPasswordAsync(user, registerDto.Password);
        //    var result = await _userManager.CreateAsync(user);
        //    if (result.Succeeded)
        //    {
        //        responeModel.Message = "Account created succesfully.";
        //        responeModel.StatusCode = System.Net.HttpStatusCode.Created;
        //        responeModel.Message = "Email taken";
        //        responeModel.Data = user;
        //    }
        //    return responeModel;
        //}

        public async Task<ResponeModel> Login(int EmpCode)
        {

            ResponeModel responeModel = new ResponeModel();
            EmployeeDetails employeeDetails = null;
            employeeDetails = await _employeeRepository.GetEmployeeDetailsWithEmpCode(EmpCode);
            if (employeeDetails == null)
            {
                responeModel.Message = "The given user is unautorized.";
                responeModel.StatusCode = System.Net.HttpStatusCode.Unauthorized;
                return responeModel;
            }


            if (employeeDetails != null && employeeDetails.empId != 0)
            {
                string otpcode;
                Random r = new Random();
                otpcode = r.Next(100000, 1000000).ToString("D6");
                string htmlOtpContent = @"<div style='font-family: Helvetica,Arial,sans-serif;min-width:1000px;overflow:auto;line-height:2'>
  <div style='margin:50px auto;width:70%;padding:20px 0'>
 
     <div style='border-bottom:1px solid #eee'>
  
        <img src='https://uat.tourprogram.cetpainfotech.com/images/logo.png' width='190px' />
     
         </div>
     
         <p style='font-size:1.1em' > Hi,</p>
          
              <p> Please use the verification code below.OTP is valid for 5 minutes.</ p >
            
                <p> If you didn’t request this, you can ignore this email.</p>
            
                <h2 style='background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;' > " + otpcode + @" </h2>
            
                <p style='font-size:0.9em;'> Regards,<br/> DFCCIL.</p>
            
                <hr style='border:none;border-top:1px solid #eee' />
            
              </div>
            </div> ";
                MailRequestModel mailRequest = new MailRequestModel()
                {

                    EmailToId = employeeDetails.empEmail,
                    EmailSubject = "OTP Code From DFCCIL",
                    EmailToName = employeeDetails.empName,
                    EmailBody = htmlOtpContent,
                };
                var OtpSednResponse = await _iNotificationRepository.SendMail(mailRequest);

                OtpCodeDetails otpCodeDetails = new OtpCodeDetails()
                {
                    OtpCode = Convert.ToInt64(otpcode),
                    Senttime = DateTime.Now,
                    IsOtpVerify = false,
                    RequestedByEmpId = employeeDetails.empId
                };
                if (OtpSednResponse != null && OtpSednResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    _dbContext.OtpCodeDetails.Add(otpCodeDetails);
                    _dbContext.SaveChanges();

                }


                responeModel.Data = new
                {
                    empId = employeeDetails.empId,
                    sentEmail = employeeDetails.empEmail
                };
                responeModel.Message = "OTP code sent to registered email id.";
                responeModel.StatusCode = System.Net.HttpStatusCode.OK;

                return responeModel;
            }

            return responeModel;

        }

        public async Task<ResponeModel> VerifyOtpCode(VerifyOtpCodeModel verifyOtpCode)
        {
            ResponeModel responeModel = new ResponeModel();
            var otpRequeuestDetails = _dbContext.OtpCodeDetails.Where(f => f.OtpCode == verifyOtpCode.OTPCode && f.RequestedByEmpId == verifyOtpCode.EmpId).OrderByDescending(d => d.Id).FirstOrDefault();
            if (otpRequeuestDetails != null)
            {
                DateTime senttime;
                string getotpcode = "";
                double CountSecound = 0;
                senttime = otpRequeuestDetails.Senttime;
                DateTime dt1 = senttime;
                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt2.Subtract(dt1);
                CountSecound = ts.TotalSeconds;
                if (CountSecound <= 300)
                {
                    EmployeeDetails employeeDetails = null;
                    employeeDetails = await _employeeRepository.GetEmployeeDetails(verifyOtpCode.EmpId);
                    EmployeeBasicDetailsModel employeeBasicDetails = new EmployeeBasicDetailsModel();

                    if (employeeDetails != null)
                    {
                        employeeBasicDetails.EmpId = employeeDetails.empId;
                        employeeBasicDetails.EmailId = employeeDetails.empEmail;
                        employeeBasicDetails.Mobile = employeeDetails.empMobileNo;
                        employeeBasicDetails.Role = employeeDetails.Role;
                        employeeBasicDetails.Name = employeeDetails.empName;
                    }
                    var token = _tokenService.CrateToken(employeeBasicDetails);
                    var Token = new { Token = token };

                    otpRequeuestDetails.IsOtpVerify = true;
                    otpRequeuestDetails.VerifyDateTime = DateTime.Now;
                    _dbContext.Update(otpRequeuestDetails);
                    _dbContext.SaveChanges();
                    responeModel.Message = "OTP Verify Successfully.";
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Data = Token;
                }
                else
                {
                    responeModel.Message = "Otp code is Expired";
                    responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
                }
            }
            else
            {
                responeModel.Message = "Invalid Otp code.";
                responeModel.StatusCode = System.Net.HttpStatusCode.BadRequest;
            }
            return responeModel;
        }
    }
}
