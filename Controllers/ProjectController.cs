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
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim);
            ProjectVM projectVM = new ProjectVM()
            {
                projects = _unitofwork.Project.GetWith(r => r.CompId == user.CompId, includeProperties: "ProjectLevel"),
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
            projectVM.project.CreatedBy = user;
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
        public IActionResult EditProject(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var compId = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim).CompId;
            var projectVM = new ProjectVM
            {
                project = _unitofwork.Project.GetFirstOrDefaultWith(r => r.PId == id, includeProperties: "CreatedBy,UpdatedBy,ProjectLevel"),
                projectItems = _unitofwork.ProjectItem.GetWith(r => r.PId == id && r.CompId == compId, includeProperties: "ProjectLevel"),
                projectLevels = _unitofwork.ProjectLevel.Where(r => r.Area == "ProjectLevel").Select(i => new SelectListItem
                {
                    Text = i.Level,
                    Value = i.PLevel.ToString()
                }),
                projectFilesList=_unitofwork.ProjectFile.GetWith(r => r.PId == id /*&& r.PFLevel==1*/,includeProperties:"FileLevel" ).ToList(),
                fileLevels = _unitofwork.FileLevel.GetAll()
                .Select(i => new SelectListItem
                {
                    Text = i.FLevel,
                    Value = i.PFLevel.ToString(),
                })
            };
            return View(projectVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProject(ProjectVM obj, IFormFileCollection? files)
        {
            if (ModelState.IsValid)
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
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
                        obj2.PId = obj.project.PId;
                        _unitofwork.ProjectFile.Add(obj2);
                    }
                }
                foreach (var item in obj.projectFilesList)
                {
                    var updated = _unitofwork.ProjectFile.GetFirstOrDefault(r => r.PFId == item.PFId);
                    if (updated.PFLevel != item.PFLevel)
                    {
                        updated.PFLevel = item.PFLevel;
                        _unitofwork.ProjectFile.Update(updated);
                    }
                }
                obj.project.UpdatedAt = DateTime.Now;
                obj.project.CreatedBy = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == obj.project.CreaterId);
                obj.project.UpdatedBy = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim);
                _unitofwork.Project.Update(obj.project);
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
                projectFilesList = _unitofwork.ProjectFile.GetWith(r => r.PId == Id && r.PFLevel == 1).ToList(),
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
                projectItems = _unitofwork.ProjectItem.GetWith(r => r.PId == Id && r.CompId == compId, includeProperties: "Project,InChargeUser").OrderBy(r => r.OrderColumn + "." + r.PSId),
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
                slworkers = _unitofwork.ApplicationUser.GetWith(r => r.CompId == user.CompId)
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })

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
        public IActionResult CreateProjectItem(string submit, ProjectVM obj, IFormFileCollection? files)
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
                if (files != null)
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
                        obj2.Project = obj.projectItem.Project;
                        obj2.CompId = obj.projectItem.CompId;
                        obj2.ProjectItem = obj.projectItem;
                        _unitofwork.ProjectFile.Add(obj2);
                    }
                }
                obj.projectItem.UpdaterId = claim;
                _unitofwork.ProjectItem.Add(obj.projectItem);
                _unitofwork.Save();
                return RedirectToAction("Index", obj.projectItem.Project.PId);
            }
            return View(obj);
        }
        public IActionResult DetailProjectItem(int Id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var compId = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim).CompId;
            var projectVM = new ProjectVM
            {
                projectItem = _unitofwork.ProjectItem.GetFirstOrDefault(r => r.PSId == Id && r.CompId == compId),
                projectFilesList = _unitofwork.ProjectFile.GetWith(r => r.PSId == Id && r.CompId == compId).ToList(),
            };
            return PartialView("_DetailProjectItem", projectVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProjectItem(string submit, IEnumerable<ProjectFile> obj22, IFormFileCollection? files, ProjectVM obj)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
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
                        obj2.PSId = obj.projectItem.PSId;
                        _unitofwork.ProjectFile.Add(obj2);
                    }


                    var projectItem = _unitofwork.ProjectItem.GetFirstOrDefault(r => r.PSId == obj.projectItem.PSId);
                    projectItem.Description = obj.projectItem.Description;
                    projectItem.DueDate = obj.projectItem.DueDate;
                    projectItem.StartDate = obj.projectItem.StartDate;

                    projectItem.UpdatedAt = DateTime.Now;
                    projectItem.UpdaterId = claim;

                    _unitofwork.ProjectItem.Update(projectItem);
                    _unitofwork.Save();
                    return RedirectToAction("Index", obj.projectItem.PId);
                }
            }
            return View(obj);

        }
        /* Result Areas */


        public IActionResult ShowResultsList(int id)
        {
            ProjectVM projectVM = new()
            {
                projectItemResults = _unitofwork.ProjectItemResult.GetWith(r => r.PSId == id, includeProperties: "ProjectLevel")
            };
            return PartialView("_ProjectItemResults", projectVM);
        }

        public IActionResult AddResult(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            var compId = _unitofwork.ApplicationUser.GetFirstOrDefault(r => r.Id == claim).CompId;
            ProjectVM projectVM = new()
            {
                projectItem = _unitofwork.ProjectItem.GetFirstOrDefaultWith(r => r.PSId == id),
                projectItemResult = new(),
                slworkers = _unitofwork.ApplicationUser.GetWith(r => r.CompId == compId)
                .Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                }),
                projectLevels = _unitofwork.ProjectLevel.Where(r => r.Area == "ProjectItem").Select(i => new SelectListItem
                {
                    Text = i.Level,
                    Value = i.PLevel.ToString()
                }),
            };
            return PartialView("_NewProjectItemResult", projectVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddResult(string submit, ProjectVM obj, IFormFileCollection? files)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
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
                        obj2.ProjectItemResult = obj.projectItemResult;
                        _unitofwork.ProjectFile.Add(obj2);
                    }
                }
                var orderColumn = _unitofwork.ProjectItem.Where(r => r.PSId == obj.projectItemResult.PSId).ToList()[0].OrderColumn;
                if (orderColumn.IndexOf(".") > 0)
                {
                    foreach (var item in _unitofwork.ProjectItem.Where(r => r.OrderColumn == orderColumn + "%"))
                    {
                        _unitofwork.ProjectItem.Update(item);
                    }
                }
                _unitofwork.ProjectItemResult.Add(obj.projectItemResult);
                _unitofwork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        /* Result Areas */
        public IActionResult Result(int id)
        {
            ProjectVM projectVM = new()
            {
                projectItemResult = _unitofwork.ProjectItemResult.GetFirstOrDefaultWith(r => r.PSRId == id, includeProperties: "ProjectLevel,CreatedBy"),
                projectLevels = _unitofwork.ProjectLevel.Where(r => r.Area == "ProjectItem").Select(i => new SelectListItem
                {
                    Text = i.Level,
                    Value = i.PLevel.ToString()
                }),
            };
            return PartialView("_ProjectItemResult", projectVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateResult(string submit, ProjectVM obj, IFormFileCollection? files)
        {
            if (ModelState.IsValid && submit == "Save")
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (files != null)
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
                        obj2.ProjectItemResult = obj.projectItemResult;
                        _unitofwork.ProjectFile.Add(obj2);
                    }
                    
                    _unitofwork.ProjectItemResult.Update(obj.projectItemResult);
                    _unitofwork.Save();
                    return RedirectToAction("Index");
                }
            }
            return View(obj);
        }
    }
}
