using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class ApplicationUserRoleRepository : Repository<ApplicationUserRole>, IApplicationUserRoleRepository
    {
        private ApplicationDbContext _db;
        public ApplicationUserRoleRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(ApplicationUserRole obj)
        {
            _db.ApplicationUserRoles.Update(obj);
        }
    }
}
