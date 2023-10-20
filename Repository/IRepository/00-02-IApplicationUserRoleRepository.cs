using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IApplicationUserRoleRepository: IRepository<ApplicationUserRole>
    {        
        void Update(ApplicationUserRole obj);
    }
}
