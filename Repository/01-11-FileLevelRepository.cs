using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class FileLevelRepository : Repository<FileLevel>, IFileLevelRepository
    {
        private ApplicationDbContext _db;
        public FileLevelRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(FileLevel obj)
        {
            _db.FileLevels.Update(obj);
        }
    }
}
