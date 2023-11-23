using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourProgram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourListingController : ControllerBase
    {
        private readonly ITourListingRepository _tourListingRepository;
        public TourListingController(ITourListingRepository tourListingRepository)
        {
            _tourListingRepository = tourListingRepository;
        }


        // GET api/<TourListingController>/5
        [HttpGet("GetTourRequest/{empId}")]
        public async Task<ResponeModel> GetTourRequest(int empId)
        {
            var response = await _tourListingRepository.GetTourRequest(empId);
            return response;
        }
        // GET api/<TourListingController>/5
        [HttpGet("FinanceProcessing/{recipientId}")]
        public async Task<ResponeModel> Get(int recipientId)
        {
            var response = await _tourListingRepository.GetTourPlanList(recipientId);
            return response;
        }

    }
}
