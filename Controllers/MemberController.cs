using Microsoft.AspNetCore.Mvc;

namespace SeniorLearnSystem.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
