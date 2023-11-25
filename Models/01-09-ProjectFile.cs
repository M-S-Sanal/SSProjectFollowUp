﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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
        public int FNo { get; set; }
        public string FExtention { get; set; }

        public int? PId { get; set; }
        [ForeignKey("PId")]
        [ValidateNever]
        public Project? Project { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        [ValidateNever]
        public Company? Company { get; set; }
        public string? CreaterId { get; set; }
        [ForeignKey("CreaterId")]
        [ValidateNever]
        public ApplicationUser? CreatedBy { get; set; }
    }
}
