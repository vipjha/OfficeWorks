using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.UsersDtos;

namespace TourProgram.BAL.Repository.Interface
{
    public interface IAccountRepository
    {
        //public Task<ResponeModel> AccountCreate(RegisterDto registerDto);
        public Task<ResponeModel> Login(int EmpCode);
        public Task<ResponeModel> VerifyOtpCode(VerifyOtpCodeModel verifyOtpCode);

    }
}
