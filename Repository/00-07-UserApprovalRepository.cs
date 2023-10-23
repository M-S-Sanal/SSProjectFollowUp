using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class UserApprovalRepository : Repository<UserApproval>, IUserApprovalRepository
    {
        private ApplicationDbContext _db;
        public UserApprovalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(UserApproval obj)
        {
            _db.UserApprovals.Update(obj);
        }
    }
}
