using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class ProjectFileRepository : Repository<ProjectFile>, IProjectFileRepository
    {
        private ApplicationDbContext _db;
        public ProjectFileRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ProjectFile obj)
        {
            _db.ProjectFiles.Update(obj);
        }
    }
}
