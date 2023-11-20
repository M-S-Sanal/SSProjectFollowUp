using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.ViewModels
{
    public class AdminVM
    {
        public string? idall { get; set; }
        public int? count { get; set; }
        public int? compid { get; set; }
        public string? someType { get; set; }

        public ApplicationUser? applicationUser0 { get; set; }
        
        public Company? company { get; set; }
        public UserApproval? userApproval { get; set; }
        public CompanyCross? companyCross { get; set; }


        public IEnumerable<UserApproval>? userApprovals { get; set; }
        public IEnumerable<ApplicationUser>? applicationUsers { get; set; }

        


        
        public IEnumerable<CompanyCross>? companyCrosses { get; set; }
        
        [ValidateNever]
        public IEnumerable<SelectListItem> suserRoles { get; set; }


        public ApplicationUserRole? applicationUserRole { get; set; }
        public List<CompanyCross>? companyCrossesList { get; set; }



        [ValidateNever]
        public IEnumerable<SelectListItem> scompanies { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> sCompanyCrossesDepartment { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> sCompanyCrossesSection { get; set; }

    }
}
