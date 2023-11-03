using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class CompanyCross
    {
        [Key]
        public int CrossId { get; set; }
        public int CompId { get; set; }
        [ForeignKey("CompId")]
        [ValidateNever]
        public Company Company { get; set; }
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department? Department { get; set; }
        public int? SectionId { get; set; }
        [ForeignKey("SectionId")]
        [ValidateNever]
        public Section? Section { get; set; }
    }
}
