using Humanizer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;
using SSProjectFollowUp.ViewModels;
using System.Security.Claims;

using static System.Net.Mime.MediaTypeNames;

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
            AdminVM adminVM = new AdminVM();
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
            string partial = "";
            switch (ff)
            {
                case "Company":
                    partial = "_" + ff;
                    adminVM = new AdminVM()
                    {
                        company = _unitofwork.Company.GetFirstOrDefault(r => r.CompId == user.CompId)
                    };
                    break;
                case "UserList":
                    partial = "_" + ff;
                    adminVM = new AdminVM()
                    {
                        applicationUser0 = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == claim, includeProperties: "Company,Department,Section,UserRoles.Role"),
                        applicationUsers = _unitofwork.ApplicationUser.GetWith(r => r.Id == claim, includeProperties: "Company,Department,Section,UserRoles.Role")
                    };
                    break;
                case "Approval":
                    partial = "_UserApproval";
                    adminVM = new AdminVM()
                    {
                        userApprovals = _unitofwork.UserApproval.
                                        GetWith(r => r.ToCompId == user.CompId && r.RequestType == "a1" && (r.ToUserId == claim || r.ToCompAdminId == claim), includeProperties: "ApplicantUser")
                    };

                    break;
                case "Organization":
                    partial = "_Organization";
                    adminVM = new AdminVM()
                    {
                        companyCrosses = _unitofwork.CompanyCross.GetWith(r => r.CompId == user.CompId, includeProperties: "Department"),
                        applicationUser0 = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == claim, includeProperties: "UserRoles.Role")
                    };
                    break;
                case "Department":
                    partial = "_Department";
                    adminVM = new AdminVM()
                    {
                        companyCrosses = _unitofwork.CompanyCross.GetWith(r => r.CompId == user.CompId && r.DepartmentId == Convert.ToInt32(ss), includeProperties: "Department,Section"),
                        applicationUser0 = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == claim, includeProperties: "UserRoles.Role")
                    };
                    break;
                case "Section":
                    partial = "_Section";
                    adminVM = new AdminVM()
                    {
                        companyCrosses = _unitofwork.CompanyCross.GetWith(r => r.CompId == user.CompId && r.SectionId == Convert.ToInt32(ss), includeProperties: "Department,Section"),
                        applicationUser0 = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == claim, includeProperties: "UserRoles.Role"),
                        applicationUsers = _unitofwork.ApplicationUser.GetWith(r => r.SectionId == Convert.ToInt32(ss))
                    };
                    break;
                case "EditCompanyUser":
                    partial = "_EditUser";
                    var compid = _unitofwork.ApplicationUser.GetFirstOrDefault(y => y.Id == ss).CompId;
                    adminVM = new AdminVM()
                    {
                        applicationUser0 = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == ss, includeProperties: "Company,Department,Section,UserRoles.Role"),
                        suserRoles = _unitofwork.ApplicationRole.GetAll().Select(i => new SelectListItem
                        {
                            Text = i.Name,
                            Value = i.Id
                        }),
                        sCompanyCrossesDepartment = _unitofwork.CompanyCross.GetWith(r => r.CompId == compid, includeProperties: "Department")
                        .Select(i => new SelectListItem
                        {
                            Text = i.Department.DepartmentName,
                            Value = i.DepartmentId.ToString()
                        }).DistinctBy(i => i.Value),
                        sCompanyCrossesSection = _unitofwork.CompanyCross.GetWith(r => r.CompId == compid && r.SectionId != null, includeProperties: "Section")
                        .Select(i => new SelectListItem
                        {
                            Text = i.Section.SectionName,
                            Value = i.SectionId.ToString()
                        }),
                        applicationUserRole = _unitofwork.ApplicationUserRole.GetFirstOrDefaultWith(r => r.UserId == ss, includeProperties: "User,Role")
                    };
                    break;
            }
            return PartialView(partial, adminVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCompany(string submit, Company obj)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                _unitofwork.Company.Add(obj);
                var user = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim);
                user.Company = obj;
                var role = _unitofwork.ApplicationRole.GetFirstOrDefault(r => r.Name == "CompanyAdmin");
                var userrole = new ApplicationUserRole();
                userrole.User = user;
                userrole.Role = role;
                userrole.RoleId = role.Id;
                userrole.UserId = claim;
                _unitofwork.ApplicationUserRole.Update(userrole);
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UserApproval(AdminVM adminVM, string submit)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                var compid = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim).CompId;
                UserApproval application = _unitofwork.UserApproval.GetFirstOrDefault(r => r.UAId == Convert.ToInt32(adminVM.idall) && r.ToCompId == compid);
                application.RequestType = submit;
                if (submit == "Approve")
                {
                    ApplicationUser applicant = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == application.ApplicantId);
                    ApplicationUserRole role = _unitofwork.ApplicationUserRole.GetFirstOrDefault(r => r.UserId == applicant.Id);
                    Company oldcompany = _unitofwork.Company.GetFirstOrDefault(r => r.CompId == applicant.CompId);
                    applicant.CompId = compid;
                    _unitofwork.ApplicationUserRole.Remove(role);
                    _unitofwork.ApplicationUser.Update(applicant);
                    _unitofwork.Company.Remove(oldcompany);

                }
                _unitofwork.UserApproval.Update(application);
                _unitofwork.Save();
            }
            return RedirectToAction("Index");
        }
        public IActionResult AddOrganizationPart(string ff, int? ss)
        {
            if (ss == null)
            {
                ss = 0;
            }
            else
            {
                ss = ss + 1;
            }
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            int? compid = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim).CompId;
            AdminVM adminVM = new AdminVM()
            {
                count = ss,
                compid = compid,
                someType = ff
            };
            return PartialView("_AddOrgPart", adminVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveOrganizationPart(AdminVM obj, string submit)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

                for (int i = 0; i < obj.companyCrossesList.Count; i++)
                {
                    if (obj.companyCrossesList.ToList()[i].Section != null)
                    {
                        //obj.companyCrossesList[i].Department = _unitofwork.Department.GetFirstOrDefault(r => r.DepartmentId == obj.companyCrossesList[i].DepartmentId);
                        _unitofwork.Section.Add(obj.companyCrossesList[i].Section);
                    }
                    else
                    {
                        obj.companyCrossesList[i].Section = null;
                    }
                    if (obj.companyCrossesList.ToList()[i].Department != null)
                    {
                        _unitofwork.Department.Add(obj.companyCrossesList[i].Department);
                    }
                    else
                    {
                        obj.companyCrossesList[i].Department = null;
                    }
                    _unitofwork.CompanyCross.Add(obj.companyCrossesList[i]);
                }

                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCompany(AdminVM obj, string submit)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                _unitofwork.Company.Update(obj.company);
                _unitofwork.Save();
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCompanyUser(AdminVM obj, string submit)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                var userRole = _unitofwork.ApplicationUserRole.GetFirstOrDefault(r => r.UserId == obj.applicationUser0.Id);
                _unitofwork.ApplicationUserRole.Remove(userRole);

                _unitofwork.ApplicationUserRole.Add(obj.applicationUserRole);
                var user = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == obj.applicationUser0.Id);
                var propsList = typeof(ApplicationUser).GetProperties();
                if (user != obj.applicationUser0)
                {
                    user.UserName = obj.applicationUser0.UserName;
                    user.Email = obj.applicationUser0.Email;
                }
                _unitofwork.ApplicationUser.Update(obj.applicationUser0);
                _unitofwork.Save();
            }
            return View("Index");
        }

        #region API CALLS

        [HttpGet]

        public ActionResult GetSection(int deptid)
        {

            IEnumerable<SelectListItem> sections = _unitofwork.CompanyCross.GetWith(r => r.DepartmentId == deptid && r.SectionId != null, includeProperties: "Section")
                .Select(i => new SelectListItem
                {
                    Text = i.Section.SectionName,
                    Value = i.SectionId.ToString()
                });
            return Json(sections);
        }
        #endregion
    }
}
