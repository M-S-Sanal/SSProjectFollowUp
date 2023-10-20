using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SSProjectFollowUp.Models
{
    public class Company
    {
        [Key]
        public int CompId { get; set; }
        public string? CompanyName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        [Required]
        [Column("StartDate", TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column("LockDate", TypeName = "Date")]
        public DateTime? LockDate { get; set; }
        public int UserCapacity { get; set; }
    }
}
