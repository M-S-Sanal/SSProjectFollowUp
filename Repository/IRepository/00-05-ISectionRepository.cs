using SSProjectFollowUp.Models;

namespace SSProjectFollowUp.Repository.IRepository
{
    public interface ISectionRepository: IRepository<Section>
    {        
        void Update(Section obj);
    }
}
