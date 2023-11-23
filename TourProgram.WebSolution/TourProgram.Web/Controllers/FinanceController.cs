using Microsoft.AspNetCore.Mvc;

namespace TourProgram.Web.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AdvanceApproval()
        {
            return View();
        }
        public IActionResult ApproveClaim()
        {
            return View();
        }
        public IActionResult ApproveClaimFinanceProcessing()
        {
            return View();
        }
        public IActionResult AdvanceApprovalBulkDownload()
        {
            return View();
        }
        public IActionResult AdvanceApprovalBanking()
        {
            return View();
        }
        public IActionResult AdvanceApprovalBankingBulkDownload()
        {
            return View();
        }
    }
}
