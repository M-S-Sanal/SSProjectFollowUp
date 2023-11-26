using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IProjectLevelRepository : IRepository<ProjectLevel>
    {
        void Update(ProjectLevel obj);
    }
}
