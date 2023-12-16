using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class ProjectItemResultRepository : Repository<ProjectItemResult>, IProjectItemResultRepository
    {
        private ApplicationDbContext _db;
        public ProjectItemResultRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProjectItemResult obj)
        {
            _db.ProjectItemResults.Update(obj);
        }
    }
}
