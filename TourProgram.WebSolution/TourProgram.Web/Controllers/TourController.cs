using Microsoft.AspNetCore.Mvc;

namespace TourProgram.Web.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TourRequest()
        {
            return View();
        }
        public IActionResult TourClaim()
        {
            return View();
        }
    }
}
