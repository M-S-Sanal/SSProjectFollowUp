using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProject(string submit, ProjectVM obj, IFormFileCollection? files)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (ModelState.IsValid && submit == "Save")
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null || files.Count != 0)
                {
                    var uploads = Path.Combine(wwwRootPath, @"Documents");
                    for (int i = 0; i < files.Count; i++)
                    {
                        string fileName = Guid.NewGuid().ToString();
                        var extention = Path.GetExtension(files[i].FileName);
                        using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + "-" + i.ToString() + extention), FileMode.Create))
                        {
                            files[i].CopyTo(fileStreams);
                        }
                        ProjectFile obj2 = new ProjectFile
                        {
                            FName = files[i].FileName,
                            FNo = 0,
                            FExtention = extention,
                            FUrl = fileName,
                        };
                        obj2.Project = obj.project;
                        obj2.CompId = obj.project.CompId;
                        _unitofwork.ProjectFile.Add(obj2);
                    }
                }
                obj.project.CreatedBy = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim);
                obj.project.PLevel = 1;
                _unitofwork.Project.Add(obj.project);
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult ProjectDetail(int Id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var compId = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == claim).CompId;
            var projectVM = new ProjectVM
            {
                project = _unitofwork.Project.GetFirstOrDefault(r => r.PId == Id && r.CompId == compId),
            };
            return PartialView("_ProjectDetail", projectVM);
        }
        


        public IActionResult NewFile()
        {
            return PartialView("_FileAdd");
        }

        public IActionResult ProjectFill(int Id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var compId = _unitofwork.ApplicationUser.GetFirstOrDefaultWith(r => r.Id == claim).CompId;
            var projectVM = new ProjectVM
            {
                project = _unitofwork.Project.GetFirstOrDefault(r => r.PId == Id && r.CompId == compId),
                projectItems = _unitofwork.ProjectItem.GetWith(r => r.PId == Id && r.CompId == compId, includeProperties: "Project").OrderBy(r => r.OrderColumn + "." + r.PSId),
            };
            return PartialView("_ProjectItem", projectVM);
        }


        public IActionResult CreateProjectItem(int id, int? PSSid, string? OC)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim);
            ProjectVM projectVM = new()
            {
                project = _unitofwork.Project.GetFirstOrDefault(r => r.PId == id && r.CompId == user.CompId),
                projectItem = new(),

            };
            projectVM.projectItem.OrderColumn = OC + "." + PSSid;
            if (OC == null)
            {
                OC = id.ToString();
                projectVM.projectItem.OrderColumn = OC;
            }
            projectVM.projectItem.PId = id;
            projectVM.projectItem.PSSId = PSSid;
            projectVM.projectItem.CompId = user.CompId;
            return PartialView("_CreateProjectItem", projectVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProjectItem(string submit, ProjectVM obj)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                obj.projectItem.Project = _unitofwork.Project.GetFirstOrDefault(r => r.PId == obj.projectItem.PId);
                if (obj.projectItem.Project.PLevel == 1)
                {
                    obj.projectItem.Project.PLevel = 2;
                }
                obj.projectItem.ProPlevel = obj.projectItem.Project.PLevel;
                
                obj.projectItem.UpdaterId = claim;
                _unitofwork.ProjectItem.Add(obj.projectItem);
                _unitofwork.Save();
                return RedirectToAction("Index", obj.projectItem.Project.PId);
            }
            return View(obj);
        }

    }
}
