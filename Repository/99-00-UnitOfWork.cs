
using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.Repository.IRepository;

namespace SSProjectFollowUp.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            ApplicationUser = new ApplicationUserRepository(_db);
            ApplicationRole = new ApplicationRoleRepository(_db);
            ApplicationUserRole = new ApplicationUserRoleRepository(_db);
            Company = new CompanyRepository(_db);
            Department = new DepartmentRepository(_db);
            Section = new SectionRepository(_db);
            CompanyCross = new CompanyCrossRepository(_db);


        }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IApplicationRoleRepository ApplicationRole { get; private set; }
        public IApplicationUserRoleRepository ApplicationUserRole { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public ISectionRepository Section { get; private set; }        
        public ICompanyCrossRepository CompanyCross { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }

}
