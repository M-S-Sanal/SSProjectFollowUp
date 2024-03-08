using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.ViewModels
{
    public class ProjectVM
    {
        public Project? project { get; set; }
        public ProjectItem? projectItem { get; set; }
        public ProjectItemResult? projectItemResult { get; set; }

        public IEnumerable<Project>? projects { get; set; }
        public IEnumerable<ProjectItem>? projectItems { get; set; }
        public IEnumerable<ProjectItemResult>? projectItemResults { get; set; }
        public BusinessCase? businessCase { get; set; }

        public ProjectTimeLine? projectTimeLine { get; set; }


        public IEnumerable<SelectListItem>? slworkers { get; set; }
        public IEnumerable<ProjectFile>? projectFiles { get; set; }
        public List<ProjectTimeLine>? projectTimeLines { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> projectLevels { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> fileLevels { get; set; }
        public List<ProjectFile>? projectFilesList { get; set; }

    }
}
