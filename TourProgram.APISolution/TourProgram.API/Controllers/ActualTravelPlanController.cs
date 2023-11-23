using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;

namespace TourProgram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActualTravelPlanController : ControllerBase
    {
        private readonly IActualTravelPlanRepository _actualTravelPlan;
        public ActualTravelPlanController(IActualTravelPlanRepository actualTravelPlan)
        {
            _actualTravelPlan = actualTravelPlan;
        }

       /* [HttpGet]
        public async Task<ResponeModel> Get()
        {
            var response = await _actualTravelPlan.Get(0);
            return response;
        }

        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await _actualTravelPlan.Get(id);
            return response;
        }

        [HttpPost("Create")]
        public async Task<ResponeModel> Create([FromBody] ActualTravelPlanDto actualTravelPlanDto)
        {
            var response = await _actualTravelPlan.Create(actualTravelPlanDto);
            return response;
        }*/

    }
}
