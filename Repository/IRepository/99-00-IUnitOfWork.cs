namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IUnitOfWork
    {      

        IApplicationUserRepository ApplicationUser { get; }
        IApplicationRoleRepository ApplicationRole { get; }
        IApplicationUserRoleRepository ApplicationUserRole { get; }
        ICompanyRepository Company { get; }
        IDepartmentRepository Department { get; }
        ISectionRepository Section { get; }
        ICompanyCrossRepository CompanyCross { get; }
        IUserApprovalRepository UserApproval { get; }

        IProjectRepository Project { get; }
        IProjectFileRepository ProjectFile { get; }
        IProjectLevelRepository ProjectLevel { get; }
        void Save();
    }
}
