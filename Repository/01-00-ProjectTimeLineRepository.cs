using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class ProjectTimeLineRepository : Repository<ProjectTimeLine>, IProjectTimeLineRepository
    {
        private ApplicationDbContext _db;
        public ProjectTimeLineRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProjectTimeLine obj)
        {
            _db.ProjectTimeLines.Update(obj);
        }
    }
}
