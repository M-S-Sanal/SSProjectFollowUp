using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface ICompanyRepository: IRepository<Company>
    {        
        void Update(Company obj);
    }
}
