using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IProjectTimeLineRepository : IRepository<ProjectTimeLine>
    {
        void Update(ProjectTimeLine obj);
    }
}
