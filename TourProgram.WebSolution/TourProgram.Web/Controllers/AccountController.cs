using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using TourProgram.Web.Models.Dashboard;
using TourProgram.Web.Models.Login;
using System.Reflection.Emit;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace TourProgram.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // then login
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(loginModel.EmpCode), Encoding.UTF8, "application/json");

                client.BaseAddress = new Uri("https://uat.tourservices.cetpainfotech.com/api/Account/login/" + loginModel.EmpCode + "");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(client.BaseAddress, null).Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var responsedetails = JsonConvert.DeserializeObject<Root_SendOtp>(apiResponse);
                    if (responsedetails != null && responsedetails.statusCode == 200 && responsedetails.data != null)
                    {
                        EmployeeBasicDetailsModel.empId = responsedetails.data.empId;
                        TempData["SentMessage"] = "OTP code send on email: " + responsedetails.data.sentEmail;
                        return RedirectToAction("VerifyOTP", "Account");
                    }
                    else
                    {
                        TempData["Inivaliduser"] = "Invalid user.";
                        return View();
                    }
                }

            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult VerifyOTP()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> VerifyOTP(VerifyOTPModel verifyOTP)
        {
            if (ModelState.IsValid)
            {
                int _empId = EmployeeBasicDetailsModel.empId;

                string _otpCode = "";
                _otpCode = verifyOTP.OtpCode1 + verifyOTP.OtpCode2 + verifyOTP.OtpCode3 + verifyOTP.OtpCode4 + verifyOTP.OtpCode5 + verifyOTP.OtpCode6;
                VerifyOtpCodeRequest verifyOtpCodeRequest = new VerifyOtpCodeRequest()
                {
                    otpCode = _otpCode,
                    empId = _empId,
                };

                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(verifyOtpCodeRequest), Encoding.UTF8, "application/json");

                client.BaseAddress = new Uri("https://uat.tourservices.cetpainfotech.com/api/Account/VerifyOtp");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var responsedetails = JsonConvert.DeserializeObject<Root>(apiResponse);
                    if (responsedetails != null && responsedetails.statusCode == 200 && responsedetails.data != null)
                    {
                        string apiToken = responsedetails.data.token;
                        var handler = new JwtSecurityTokenHandler();
                        var jwtSecurityToken = handler.ReadJwtToken(apiToken);
                        var username = jwtSecurityToken.Claims.Where(x => x.Type == "unique_name").FirstOrDefault()?.Value;
                        var role = jwtSecurityToken.Claims.Where(x => x.Type == "role").FirstOrDefault()?.Value;
                        //var userId = jwtSecurityToken.Claims.First(x => x.Type == "sid").Value;
                        var empId = jwtSecurityToken.Claims.Where(x => x.Type == "primarysid").FirstOrDefault()?.Value;
                        var mobileNo = jwtSecurityToken.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone").FirstOrDefault()?.Value;
                        var email = jwtSecurityToken.Claims.Where(x => x.Type == "email").FirstOrDefault()?.Value;
                        var EmpCode = jwtSecurityToken.Claims.Where(x => x.Type == "EmpCode").FirstOrDefault()?.Value;
                        var Designation = jwtSecurityToken.Claims.Where(x => x.Type == "Designation").FirstOrDefault()?.Value;
                        var Unit = jwtSecurityToken.Claims.Where(x => x.Type == "Unit").FirstOrDefault()?.Value;
                        var Lavel = jwtSecurityToken.Claims.Where(x => x.Type == "Lavel").FirstOrDefault()?.Value;
                        //var tokenExpiredTime = jwtSecurityToken.Claims.First(x => x.Type == "exp").Value;

                        var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.Role, role),
                            new Claim("Token",apiToken),
                            new Claim("empId",empId),
                            new Claim("email",email),
                            new Claim("empCode",EmpCode),
                            new Claim("empDesignation",Designation),
                            new Claim("empUnit",Unit),
                            new Claim("empGrade",Lavel),
                            new Claim("mobileNo",mobileNo),

                            }, CookieAuthenticationDefaults.AuthenticationScheme);

                        EmployeeBasicDetailsModel.empId = Convert.ToInt32(empId);
                        //EmployeeBasicDetailsModel.empId = Convert.ToInt32(empId);
                        EmployeeBasicDetailsModel.empCode = EmpCode;
                        EmployeeBasicDetailsModel.empDesignation = Designation;
                        EmployeeBasicDetailsModel.empUnit = Unit;
                        EmployeeBasicDetailsModel.empGrade = Lavel;
                        EmployeeBasicDetailsModel.EmailId = email;
                        EmployeeBasicDetailsModel.Role = role;
                        EmployeeBasicDetailsModel.Mobile = mobileNo;
                        EmployeeBasicDetailsModel.Name = username;

                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                        {
                            ExpiresUtc = DateTimeOffset.Now.AddMinutes(25),
                            IsPersistent = true,
                            AllowRefresh = true,
                        });
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["InivalidOtpCode"] = "Invalid OTP Code.";
                        return View();
                    }
                }

            }
            return View();
        }

        partial class VerifyOtpCodeRequest
        {
            public string otpCode { get; set; }
            public int empId { get; set; }
        }

        public class Data_SendOtp
        {
            public int empId { get; set; }
            public string sentEmail { get; set; }
        }
        public class Data
        {
            public string token { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public class Root
        {
            public int statusCode { get; set; }
            public string message { get; set; }
            public Data data { get; set; }
            public int dataLength { get; set; }
            public bool error { get; set; }
            public object errorDetail { get; set; }
        }
        public class Root_SendOtp
        {
            public int statusCode { get; set; }
            public string message { get; set; }
            public Data_SendOtp data { get; set; }
            public int dataLength { get; set; }
            public bool error { get; set; }
            public object errorDetail { get; set; }
        }
        public IActionResult Registeration()
        {
            return View();
        }



    }
}
