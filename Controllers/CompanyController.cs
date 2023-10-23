using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSProjectFollowUp.Models;
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
                if (_unitofwork.UserApproval.GetFirstOrDefault(r => r.ApplicantId == claim) == null)
                {
                    ViewBag.assigned = 1;
                }
                else
                {
                    ViewBag.assigned = 0;
                }
                return PartialView("_CompanyChoose");
            }
            return View();
        }

        public IActionResult Choice(string ff)
        {
            if (ff == "a1")
            {
                AdminVM adminVM = new AdminVM()
                {
                    company = new Company(),
                    scompanies = _unitofwork.Company.GetAll().Select(i => new SelectListItem
                    {
                        Text = i.CompanyName,
                        Value = i.CompId.ToString()
                    }),
                };
                return PartialView("_Join2Team", adminVM);
            }
            return PartialView("_CreateCompany");
        }

        public IActionResult SearchUser(string ff)
        {
            AdminVM adminVM = new AdminVM()
            {
                applicationUser0 = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.UserName == ff)
            };

            return PartialView("_ResultUser", adminVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Join2Team(string submit, AdminVM obj)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                obj.userApproval.ApplicantId = claim;
                IEnumerable<ApplicationUser> companyadmin = _unitofwork.ApplicationUser
                    .GetWith(r => r.CompId == obj.userApproval.ToCompId, includeProperties: "Company,Department,Section,UserRoles.Role");
                ApplicationUser appadmin = companyadmin.FirstOrDefault(r => r.UserRoles.ToList()[0].Role.Name == "CompanyAdmin");
                obj.userApproval.RequestType = "a1";
                _unitofwork.UserApproval.Add(obj.userApproval);
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
