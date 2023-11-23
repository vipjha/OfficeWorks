using Microsoft.AspNetCore.Mvc;

namespace TourProgram.Web.Controllers
{
    public class ApprovalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TourApproval()
        {
            return View();
        }
    }
}
