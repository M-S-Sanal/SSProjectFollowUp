using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IDepartmentRepository: IRepository<Department>
    {        
        void Update(Department obj);
    }
}
