using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.Response;
using TourProgram.Model.Dtos.TourStatus;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourProgram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourStatusController : ControllerBase
    {
        private readonly ITourStatusRepository _tourStatusRepository;
        public TourStatusController(ITourStatusRepository tourStatusRepository)
        {
            _tourStatusRepository = tourStatusRepository;
        }
         
        [HttpPut("Update/TourRequestStatus")]
        public async Task<ResponeModel> UpdateTourRequestStatus([FromForm] TourRequestStatusModel statusModel)
        {
            var response = await _tourStatusRepository.UpdateTourRequestStatus(statusModel);
            return response;
        }
        [HttpPut("Update/TourRequestAmount")]
        public async Task<ResponeModel> UpdateTourRequestAmount([FromForm] TourRequestAmountStatusModel statusModel)
        {
            var response = await _tourStatusRepository.UpdateTourRequestAmount(statusModel);
            return response;
        }

    }
}
