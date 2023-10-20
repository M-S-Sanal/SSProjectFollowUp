using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class ApplicationRoleRepository : Repository<ApplicationRole>, IApplicationRoleRepository
    {
        private ApplicationDbContext _db;
        public ApplicationRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationRole obj)
        {
            _db.ApplicationRoles.Update(obj);
        }
    }
}
