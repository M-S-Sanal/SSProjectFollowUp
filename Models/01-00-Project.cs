using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SSProjectFollowUp.Models
{
    public class Project
    {
        [Key]
        [Column(Order = 0)]
        public int PId { get; set; }
        [Required]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        [Column("CreatedAt", TypeName = "DateTime2(0)")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required]
        public string? CreaterId { get; set; }
        [ForeignKey("CreaterId")]
        [ValidateNever]
        public ApplicationUser? CreatedBy { get; set; }

        [Column("UpdatedAt", TypeName = "DateTime2(0)")]
        public DateTime? UpdatedAt { get; set; }

        public string? UpdaterId { get; set; }
        [ForeignKey("UpdaterId")]
        [ValidateNever]
        public ApplicationUser? UpdatedBy { get; set; }

        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        [ValidateNever]
        public Company? Company { get; set; }
    }
}
