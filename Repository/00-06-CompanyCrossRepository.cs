using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class CompanyCrossRepository : Repository<CompanyCross>, ICompanyCrossRepository
    {
        private ApplicationDbContext _db;
        public CompanyCrossRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(CompanyCross obj)
        {
            _db.CompanyCrosses.Update(obj);
        }
    }
}
