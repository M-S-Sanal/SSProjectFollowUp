using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IProjectItemRepository : IRepository<ProjectItem>
    {
        void Update(ProjectItem obj);
    }
}
