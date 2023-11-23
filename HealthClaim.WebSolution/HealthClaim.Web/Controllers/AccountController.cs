
using HealthClaim.Web.Models.Login;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using HealthClaim.Web.Models.Dashboard;

namespace HealthClaim.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // then login
                HttpClient client = new HttpClient();
                StringContent content = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");

                client.BaseAddress = new Uri("https://uat.dfccil.services.cetpainfotech.com/api/Account/login");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PostAsync(client.BaseAddress, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var responsedetails = JsonConvert.DeserializeObject<Root>(apiResponse);
                    if (responsedetails != null && responsedetails.data != null)
                    {


                        string apiToken = responsedetails.data.token;

                        var handler = new JwtSecurityTokenHandler();
                        var jwtSecurityToken = handler.ReadJwtToken(apiToken);

                        var username = jwtSecurityToken.Claims.First(x => x.Type == "name").Value;
                        var role = jwtSecurityToken.Claims.First(x => x.Type == "role").Value;
                        //var userId = jwtSecurityToken.Claims.First(x => x.Type == "sid").Value;
                        var empId = jwtSecurityToken.Claims.First(x => x.Type == "primarysid").Value;
                        var email = jwtSecurityToken.Claims.First(x => x.Type == "email").Value;
                        //var tokenExpiredTime = jwtSecurityToken.Claims.First(x => x.Type == "exp").Value;

                        var identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, username),
                            new Claim(ClaimTypes.Role, role),
                            //new Claim(ClaimTypes.Sid,userId),
                            new Claim("Token",apiToken),
                            new Claim("empId",empId),
                            new Claim("email",email),

                            }, CookieAuthenticationDefaults.AuthenticationScheme);

                        BasicDetails.Logedin_UserName = username;

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
                        TempData["Inivaliduser"] = "Invalid user.";
                        return View();
                    }
                }

            }
            return View();
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
        public IActionResult Registeration()
        {
            return View();
        }



    }
}
