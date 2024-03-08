using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SSProjectFollowUp.Data;
using SSProjectFollowUp.Models;
using SSProjectFollowUp.wwwroot;

namespace SSProjectFollowUp.DbInitializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ApplicationDbContext _db;

        public DbInitializer(
            UserManager<IdentityUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            ApplicationDbContext db)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _db = db;
        }
        public void Initialize()
        {
            //migrations if they are not applied
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex) { }
            //create roles if they are not created
            if (!_roleManager.RoleExistsAsync(SD.Role_Admin).GetAwaiter().GetResult())
            {
                _roleManager.CreateAsync(new ApplicationRole(SD.Role_Admin)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new ApplicationRole(SD.Role_Company_User)).GetAwaiter().GetResult();
                _roleManager.CreateAsync(new ApplicationRole(SD.Role_Company_Admin)).GetAwaiter().GetResult();
            }
            if (!_db.ProjectLevels.Any())
            {
                var projectLevel = new ProjectLevel() { Level = "1", Area = "ProjectLevel", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "2", Area = "ProjectLevel", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "3", Area = "ProjectLevel", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "4", Area = "ProjectLevel", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "5", Area = "ProjectLevel", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                /*For ProjectItems*/
                projectLevel = new ProjectLevel() { Level = "UnDefined", Area = "ProjectItem", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "Ok", Area = "ProjectItem", Value = 1 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "Waiting for Approval", Area = "ProjectItem", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "Waiting for Results", Area = "ProjectItem", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                /*For ProjectTimeLineStatus*/
                projectLevel = new ProjectLevel() { Level = "Current", Area = "TimeLine", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
                projectLevel = new ProjectLevel() { Level = "Not Started", Area = "TimeLine", Value = 0 };
                _db.ProjectLevels.Add(projectLevel);
            }
            if (!_db.FileLevels.Any())
            {
                /*FileStatus*/
                FileLevel fileLevel = new FileLevel() { FLevel = "Active", FValue = 0 };
                _db.FileLevels.Add(fileLevel);
                fileLevel = new FileLevel() { FLevel = "InActive", FValue = 0 };
                _db.FileLevels.Add(fileLevel);
            }
            _db.SaveChanges();
            return;
        }
    }
}
