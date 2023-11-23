using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourProgram.Model.Dtos.RaiseClaimDtos;
using TourProgram.Model.Dtos.Response;

namespace TourProgram.BAL.Repository.Interface
{
    public interface IClaimRepository
    {
        Task<ResponeModel> RaiseClaimRequest(ClaimApprovalDto claimApprovalDto);
    }
}
