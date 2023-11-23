using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;
using TourProgram.DAL.Models;
using TourProgram.Model.Dtos.EmpTourPlanDtos;
using TourProgram.Model.Dtos.RaiseClaimDtos;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimController : ControllerBase
    {
        private readonly IClaimRepository _claimRepository;
        public ClaimController(IClaimRepository claimRepository)
        {
            _claimRepository = claimRepository;
        }

        [HttpPost("RaiseClaimRequest")]
        public async Task<ResponeModel> RaiseClaimRequest([FromForm] ClaimApprovalDto claimApprovalDto)
        {
            var response = await _claimRepository.RaiseClaimRequest(claimApprovalDto);
            return response;
        }
    }
}
