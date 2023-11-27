using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class ProjectItem
    {
        [Key]
        [Column(Order = 0)]
        public int PSId { get; set; }
        [Column(Order = 1)]
        public string? Description { get; set; }
        [Column("StartDate", TypeName = "Date", Order = 2)]
        public DateTime? StartDate { get; set; }
        [Column("DueDate", TypeName = "Date", Order = 3)]
        public DateTime? DueDate { get; set; }
        [Column(Order = 4)]
        public string? InCharge { get; set; }
        [ForeignKey("InCharge")]
        [ValidateNever]
        public ApplicationUser? InChargeUser { get; set; }
        [Column(Order = 5)]
        public DateTime CreateAt { get; set; } = DateTime.Now;
        [Column(Order = 6)]
        public string? CreaterId { get; set; }
        [ForeignKey("CreaterId")]
        [ValidateNever]
        public ApplicationUser? CreatedBy { get; set; }
        [Column(Order = 7)]
        public DateTime? UpdatedAt { get; set; }
        [Column(Order = 8)]
        public string? UpdaterId { get; set; }
        [ForeignKey("UpdaterId")]
        [ValidateNever]
        public ApplicationUser? UpdatedBy { get; set; }
        [Column(Order = 9)]
        public int? ProPlevel { get; set; }
        [Column(Order = 10)]
        public int? PId { get; set; }
        [ValidateNever]
        [ForeignKey("PId")]
        public virtual Project Project { get; set; }

        [ForeignKey("ProjectLevel")]
        [Column(Order = 11)]
        public int PLevel { get; set; } = 17;
        [ValidateNever]
        public ProjectLevel ProjectLevel { get; set; }

        public int? PSSId { get; set; }
        public string? OrderColumn { get; set; }
        public int? CompId { get; set; }
        [ForeignKey("CompId")]
        [ValidateNever]
        public Company? Company { get; set; }
    }
}
