using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IProjectFileRepository : IRepository<ProjectFile>
    {
        void Update(ProjectFile obj);
    }
}
