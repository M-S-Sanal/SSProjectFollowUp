using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IBusinessCaseRepository : IRepository<BusinessCase>
    {
        void Update(BusinessCase obj);
    }
}
