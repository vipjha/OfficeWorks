using Microsoft.AspNetCore.Mvc;
using TourProgram.BAL.Repository.Interface;
using TourProgram.Model.Dtos.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourProgram.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BulkApprovalController : ControllerBase
    {
        private readonly IBulkApprovalRepository _bulkApprovalRepository;
        public BulkApprovalController(IBulkApprovalRepository bulkApproval)
        {
            _bulkApprovalRepository = bulkApproval;
        }

        // GET api/<BulkApprovalController>/5
        [HttpGet("AdvanceApproval/{empId}")]
        public async Task<ResponeModel> GetAdvanceApproval(int empId)
        {
            var response = await _bulkApprovalRepository.GetAdvanceApproval(empId);
            return response;
        }
        
        // GET api/<BulkApprovalController>/5
        [HttpGet("AdvanceApprovalBanking/{empId}")]
        public async Task<ResponeModel> AdvanceApprovalBanking(int empId)
        {
            var response = await _bulkApprovalRepository.GetAdvanceBankingApproval(empId);
            return response;
        }

        //// POST api/<BulkApprovalController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}


    }
}
