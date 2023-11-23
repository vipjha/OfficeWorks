using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "HR")]
        public IActionResult AdvanceApproved()
        {
            return View();
        }
        [Authorize(Roles = "HR")]
        public IActionResult ClaimApproved()
        {
            return View();
        }
        public IActionResult ClaimAfterDoctorReview()
        {
            return View();
        }
        public IActionResult ClaimAfterDoctorReviewFinal()
        {
            return View();
        }
        [Authorize(Roles = "Doctor")]
        public IActionResult DoctorReview()
        {
            return View();
        }
        public IActionResult DoctorReviewList()
        {
            return View();
        }
        public IActionResult FinanceStep1()
        {
            return View();
        }
        public IActionResult FinanceShiv()
        {
            return View();
        }
    }
}
