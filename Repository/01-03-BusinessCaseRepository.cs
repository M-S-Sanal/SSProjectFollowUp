using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class BusinessCaseRepository : Repository<BusinessCase>, IBusinessCaseRepository
    {
        private ApplicationDbContext _db;
        public BusinessCaseRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(BusinessCase obj)
        {
            _db.BusinessCases.Update(obj);
        }
    }
}
