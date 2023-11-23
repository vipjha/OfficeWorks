using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.Web.Controllers
{
    public class FinanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Bill Passing")]

        public IActionResult BillPassing()
        {
            return View();
        }
        [Authorize(Roles = "Finance")]

        public IActionResult Banking()
        {
            return View();
        }
    }
}
