using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.UsersDtos;

namespace TourProgram.API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpPost("login/{EmpCode}")]
        public async Task<ResponeModel> Login(int EmpCode)
        {
            ResponeModel response = await _accountRepository.Login(EmpCode);
            return response;
        }
        [HttpPost("VerifyOtp")]
        public async Task<ResponeModel> VerifyOtp(VerifyOtpCodeModel verifyOtpCode)
        {
            ResponeModel response = await _accountRepository.VerifyOtpCode(verifyOtpCode);
            return response;
        }

        //[HttpPost("register")]
        //public async Task<ResponeModel> Register(RegisterDto registerDto)
        //{
        //    ResponeModel response = await _accountRepository.AccountCreate(registerDto);
        //    return response;
        //}
    }
}

