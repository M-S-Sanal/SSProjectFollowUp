using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IApplicationRoleRepository: IRepository<ApplicationRole>
    {        
        void Update(ApplicationRole obj);
    }
}
