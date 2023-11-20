using Microsoft.AspNetCore.Identity;

namespace SSProjectFollowUp.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(string roleName) : base(roleName)
        {
        }
        public string? RoleName { get; set; }
        public virtual ICollection<ApplicationUserRole>? UserRoles { get; set; }
    }
}
