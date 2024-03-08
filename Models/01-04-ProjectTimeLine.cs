using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Storage;

namespace SSProjectFollowUp.Models
{
    public class ProjectTimeLine
    {
        [Key]
        [Column(Order = 0)]
        public int PTId { get; set; }
        public int? PId { get; set; }
        
        [ForeignKey("PId")]
        [ValidateNever]
        public virtual Project Project { get; set; }
        public int? PLevel { get; set; }
        
        [ForeignKey("PLevel")]
        [ValidateNever]
        public ProjectLevel ProjectLevel { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ForecastDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? AppliedDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ActualDate { get; set; }

        public int? StatusId { get; set; }   /* Status of level approval*/
        
        [ForeignKey("StatusId")]
        [ValidateNever]
        public ProjectLevel StatusLevel { get; set; }

        public string? StatusUserId { get; set; }

        [ForeignKey("StatusUserId")]
        [ValidateNever]
        public ApplicationUser? StatusUser { get; set; }
    }
}
