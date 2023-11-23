using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Employee;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Service
{
    public class TokenService
    {
        public readonly IConfiguration _config;
        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string CrateToken(EmployeeBasicDetailsModel employeeBasicDetails)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, employeeBasicDetails?.Name),
                new Claim(ClaimTypes.PrimarySid, employeeBasicDetails?.EmpId.ToString()),
                new Claim(ClaimTypes.MobilePhone, employeeBasicDetails.Mobile),
                new Claim(ClaimTypes.Email, employeeBasicDetails.EmailId),
                new Claim(ClaimTypes.Role, employeeBasicDetails.Role),
                new Claim(ClaimTypes.Expiration, DateTime.Now.AddMinutes(25).ToString()),
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["TokenKey"]));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(25),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

