using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.EmpTourPlanDtos;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourPlanController : ControllerBase
    {
        private readonly IEmpTourPlanRepository _empTourPlan;
        public TourPlanController(IEmpTourPlanRepository empTourPlan)
        {
            _empTourPlan = empTourPlan;
        }

       

        [HttpGet("GetTourDetails/{tourId}")]
        public async Task<ResponeModel> Get(int tourId)
        {
            var url = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + "/";

            var response = await _empTourPlan.GetTourDetails(tourId, url);
            return response;
        }

        [HttpGet("GetGradeDetail")]
        public async Task<ResponeModel> GetGradeDetail(string lavel)
        {
            var response = await _empTourPlan.GetGradeData(lavel);
            return response;
        }


        [HttpPost("TourRequest")]
        public async Task<ResponeModel> TourRequest([FromForm] EmpTourPlanRequestDto empTourPlanRequestDto)
        {
            var response = await _empTourPlan.EmpTourRequest(empTourPlanRequestDto);
            return response;
        }

       /* [HttpPut("TourRequestApproved/{id}")]
        public async Task<ResponeModel> TourRequestApproved(int id, [FromBody] EmpTourApprovedDto empTourApprovedDto)
        {
            var response = await _empTourPlan.EmpTourApprovedAmount(empTourApprovedDto, id);
            return response;
        }*/

    }
}

