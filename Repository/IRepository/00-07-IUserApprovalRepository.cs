using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IUserApprovalRepository: IRepository<UserApproval>
    {        
        void Update(UserApproval obj);
    }
}
