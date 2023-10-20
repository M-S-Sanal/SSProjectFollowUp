using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        private ApplicationDbContext _db;
        public SectionRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Section obj)
        {
            _db.Sections.Update(obj);
        }
    }
}
