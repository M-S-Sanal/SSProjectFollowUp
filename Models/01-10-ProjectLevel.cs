using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class ProjectLevel
    {
        [Key]
        [Column(Order = 0)]
        public int PLevel { get; set; }
        [Column(Order = 1)]
        public string Level { get; set; }
        public int Value { get; set; }
        public string Area { get; set; }

        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        [ValidateNever]
        public Company? Company { get; set; }

        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department? Department { get; set; }
        public int? SectionId { get; set; }
        [ForeignKey("SectionId")]
        [ValidateNever]
        public Section? Section { get; set; }

        [Column("CreatedAt", TypeName = "DateTime2(0)")]
        public DateTime? CreatedAt { get; set; }

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

    }
}
