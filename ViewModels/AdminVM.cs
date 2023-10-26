using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.ViewModels
{
    public class AdminVM
    {
        public string? idall { get; set; }

        public ApplicationUser? applicationUser0 { get; set; }

        public int? compid { get; set; }
        public Company? company { get; set; }
        public UserApproval? userApproval { get; set; }
        public IEnumerable<UserApproval>? userApprovals { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> scompanies { get; set; }
    }
}
