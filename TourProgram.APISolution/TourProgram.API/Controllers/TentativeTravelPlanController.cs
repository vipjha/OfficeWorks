using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.EmpTourPlanDtos;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.TentativeTravelPlanDtos;

namespace TourProgram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TentativeTravelPlanController : ControllerBase
    {
        private readonly ITentativeTravelPlanRepository _tentativeTravelPlan;
        public TentativeTravelPlanController(ITentativeTravelPlanRepository tentativeTravelPlan)
        {
            _tentativeTravelPlan = tentativeTravelPlan;
        }

        /*[HttpGet]
        public async Task<ResponeModel> Get()
        {
            var response = await _tentativeTravelPlan.Get(0);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await _tentativeTravelPlan.Get(id);
            return response;
        }

        [HttpPost("Create")]
        public async Task<ResponeModel> Create([FromBody] TentativeTravelPlanDto tentativeTravelPlanDto)
        {
            var response = await _tentativeTravelPlan.Create(tentativeTravelPlanDto);
            return response;
        }*/

       
    }
}

