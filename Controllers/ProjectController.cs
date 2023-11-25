using Microsoft.AspNetCore.Mvc;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;
using SSProjectFollowUp.ViewModels;
using System.Security.Claims;

namespace SSProjectFollowUp.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProjectController(IUnitOfWork unitofwork, IWebHostEnvironment webHostEnvironment)
        {
            _unitofwork = unitofwork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            ProjectVM projectVM = new ProjectVM()
            {
                projects = _unitofwork.Project.GetAll()
            };
            return View(projectVM);
        }
        public IActionResult CreateProject()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim);
            ProjectVM projectVM = new ProjectVM()
            {
                project = new Project()
            };
            projectVM.project.CompId = user.CompId;
            projectVM.project.CreatedBy= user;
            return View(projectVM);
        }

        public IActionResult NewFile()
        {
            return PartialView("_FileAdd");
        }
    }
}
