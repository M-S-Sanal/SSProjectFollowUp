using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class ProjectItemResult
    {
        [Key]
        [Column(Order = 0)]
        public int PSRId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PSRResult { get; set; }
        public string PSRComment { get; set; }

        public string? CreaterId { get; set; }
        [ForeignKey("CreaterId")]
        [ValidateNever]
        public ApplicationUser? CreatedBy { get; set; }

        public int? PSId { get; set; }
        [ForeignKey("PSId")]
        [ValidateNever]
        public ProjectItem ProjectItem { get; set; }

        [ForeignKey("ProjectLevel")]
        public int PLevel { get; set; } = 6;
        [ValidateNever]
        public ProjectLevel ProjectLevel { get; set; }

        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        [ValidateNever]
        public Company? Company { get; set; }
    }
}
