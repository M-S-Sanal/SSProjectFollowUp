using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class ProjectFile
    {
        [Key]
        public int PFId { get; set; }
        public string? FName { get; set; }
        public string? FUrl { get; set; }
        public int? FNo { get; set; }
        public string? FExtention { get; set; }

        public int? PId { get; set; }
        [ForeignKey("PId")]
        [ValidateNever]
        public Project? Project { get; set; }

        public int? PSId { get; set; }
        [ForeignKey("PSId")]
        [ValidateNever]
        public ProjectItem? ProjectItem { get; set; }

        public int? PSRId { get; set; }
        [ForeignKey("PSRId")]
        [ValidateNever]
        public ProjectItemResult? ProjectItemResult { get; set; }

        public int? BId { get; set; }
        [ForeignKey("BId")]
        [ValidateNever]
        public BusinessCase? BusinessCase { get; set; }

        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        [ValidateNever]
        public Company? Company { get; set; }

        public string? CreaterId { get; set; }
        [ForeignKey("CreaterId")]
        [ValidateNever]
        public ApplicationUser? CreatedBy { get; set; }

        public int PFLevel { get; set; } = 1;
        [ForeignKey("PFLevel")]
        [ValidateNever]
        public FileLevel? FileLevel { get; set; }
    }
}
