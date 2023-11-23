

using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Interface
{
    public interface IBulkApprovalRepository
    {
        public Task<ResponeModel> GetAdvanceApproval(int empId);
        public Task<ResponeModel> GetAdvanceBankingApproval(int empId);
    }
}
