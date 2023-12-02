using Microsoft.AspNetCore.Mvc.Rendering;
using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.ViewModels
{
    public class ProjectVM
    {
        public Project? project { get; set; }
        public ProjectItem? projectItem { get; set; }

        public IEnumerable<Project>? projects { get; set; }
        public IEnumerable<ProjectItem>? projectItems { get; set; }

        public IEnumerable<SelectListItem>? slworkers { get; set; }
    }
}
