using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SSProjectFollowUp.Repository.IRepository;
using SSProjectFollowUp.ViewModels;
using System.Security.Claims;

namespace SSProjectFollowUp.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        public CompanyController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Management(string ff, string? ss)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == claim, includeProperties: "Company");
            if (user.Company.CompanyName == "__TempCompany")
            {
                return PartialView("_CompanyChoose");
            }
            return View();
        }
    }
}
