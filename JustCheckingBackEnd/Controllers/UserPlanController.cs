using Microsoft.AspNetCore.Mvc;

namespace JustCheckingAPI.Controllers
{
    public class UserPlanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
