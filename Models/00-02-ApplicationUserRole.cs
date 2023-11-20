using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SSProjectFollowUp.Models
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        [ValidateNever]
        public virtual ApplicationUser? User { get; set; }
        [ValidateNever]
        public virtual ApplicationRole? Role { get; set; }
    }
}
