using Microsoft.AspNetCore.Mvc;

namespace SSProjectFollowUp.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
