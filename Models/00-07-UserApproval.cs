using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class UserApproval
    {
        [Key]
        public int UAId { get; set; }

        public string? ApplicantId { get; set; }
        [ForeignKey("ApplicantId")]
        [ValidateNever]
        public ApplicationUser? ApplicantUser { get; set; }

        public string? RequestType { get; set; } /* a1 || a2 */

        public int? ToCompId { get; set; }

        public string? ToUserId { get; set; }

        public string? ToUserMail { get; set; }

        public string? Introduction { get; set; }

        public string? ToCompAdminId { get; set; }

        public string? Situation { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? ApprovedAt { get; set; }
    }
}
