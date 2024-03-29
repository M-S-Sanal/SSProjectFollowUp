﻿
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
            UserApproval = new UserApprovalRepository(_db);

            Project = new ProjectRepository(_db);
            ProjectItem = new ProjectItemRepository(_db);
            ProjectItemResult = new ProjectItemResultRepository(_db);
            BusinessCase = new BusinessCaseRepository(_db);
            ProjectTimeLine = new ProjectTimeLineRepository(_db);

            ProjectFile = new ProjectFileRepository(_db);
            ProjectLevel = new ProjectLevelRepository(_db);
            FileLevel = new FileLevelRepository(_db);
        }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IApplicationRoleRepository ApplicationRole { get; private set; }
        public IApplicationUserRoleRepository ApplicationUserRole { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IDepartmentRepository Department { get; private set; }
        public ISectionRepository Section { get; private set; }        
        public ICompanyCrossRepository CompanyCross { get; private set; }
        public IUserApprovalRepository UserApproval { get; private set; }

        public IProjectRepository Project { get; private set; }
        public IProjectItemRepository ProjectItem { get; private set; }
        public IProjectItemResultRepository ProjectItemResult { get; private set; }
        public IBusinessCaseRepository BusinessCase { get; private set; }
        public IProjectTimeLineRepository ProjectTimeLine { get; private set; }

        public IProjectFileRepository ProjectFile { get; private set; }
        public IProjectLevelRepository ProjectLevel { get; private set; }
        public IFileLevelRepository FileLevel { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }

}
