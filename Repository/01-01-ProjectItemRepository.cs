using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class ProjectItemRepository : Repository<ProjectItem>, IProjectItemRepository
    {
        private ApplicationDbContext _db;
        public ProjectItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProjectItem obj)
        {
            _db.ProjectItems.Update(obj);
        }
    }
}
