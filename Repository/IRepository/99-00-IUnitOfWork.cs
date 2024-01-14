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
        IProjectItemRepository ProjectItem { get; }
        IProjectItemResultRepository ProjectItemResult { get; }
        IBusinessCaseRepository BusinessCase { get; }
        IProjectFileRepository ProjectFile { get; }
        IProjectLevelRepository ProjectLevel { get; }
        IFileLevelRepository FileLevel { get; }
        void Save();
    }
}
