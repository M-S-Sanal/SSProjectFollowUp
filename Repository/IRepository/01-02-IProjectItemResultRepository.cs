using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IProjectItemResultRepository : IRepository<ProjectItemResult>
    {
        void Update(ProjectItemResult obj);
    }
}
