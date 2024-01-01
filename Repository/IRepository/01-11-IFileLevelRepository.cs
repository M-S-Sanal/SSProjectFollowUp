
using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface IFileLevelRepository : IRepository<FileLevel>
    {
        void Update(FileLevel obj);
    }
}
