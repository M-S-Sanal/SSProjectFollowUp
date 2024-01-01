using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SSProjectFollowUp.Models
{
    public class FileLevel
    {
        [Key]
        [Column(Order = 0)]
        public int PFLevel { get; set; }
        [Column(Order = 1)]
        public string FLevel { get; set; }
        public int FValue { get; set; }

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

        [Column("UpdatedAt", TypeName = "DateTime2(0)")]
        public DateTime? UpdatedAt { get; set; }

        public string? UpdaterId { get; set; }
        [ForeignKey("UpdaterId")]
        [ValidateNever]
        public ApplicationUser? UpdatedBy { get; set; }
    }
}
