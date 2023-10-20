using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface ICompanyCrossRepository: IRepository<CompanyCross>
    {        
        void Update(CompanyCross obj);
    }
}
