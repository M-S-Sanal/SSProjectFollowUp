using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class ProjectLevelRepository : Repository<ProjectLevel>, IProjectLevelRepository
    {
        private ApplicationDbContext _db;
        public ProjectLevelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProjectLevel obj)
        {
            _db.ProjectLevels.Update(obj);
        }
    }
}
