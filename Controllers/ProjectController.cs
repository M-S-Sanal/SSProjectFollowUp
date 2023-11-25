using Microsoft.AspNetCore.Mvc;
using SSProjectFollowUp.Repository.IRepository;
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
            return View();
        }
    }
}
