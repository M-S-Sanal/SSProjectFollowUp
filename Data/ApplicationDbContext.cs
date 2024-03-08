using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Data
{
    public class ApplicationDbContext :IdentityDbContext<IdentityUser, ApplicationRole, string,
    IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<CompanyCross> CompanyCrosses { get; set; }
        public DbSet<UserApproval> UserApprovals { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectItem> ProjectItems { get; set; }
        public DbSet<ProjectItemResult> ProjectItemResults { get; set; }
        public DbSet<BusinessCase> BusinessCases { get; set; }
        public DbSet<ProjectTimeLine> ProjectTimeLines { get; set; }
        public DbSet<ProjectFile> ProjectFiles { get; set; }
        public DbSet<ProjectLevel> ProjectLevels { get; set; }
        public DbSet<FileLevel> FileLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();

            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
