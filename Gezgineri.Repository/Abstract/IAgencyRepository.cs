using Gezgineri.Entity.Models;


namespace Gezgineri.Repository.Abstract
{
    public interface IAgencyRepository : IGenericRepository<Agency>
    {
        public Task<IEnumerable<Agency>> GetAllWithIncludeAsync();
        public Task<Agency> GetAgencyByIdWithIncludeAsync(Guid id);
        public Task<Agency> GetAgencyByMemberIdWithIncludeAsync(Guid memberid);
        public Task<bool> UpdateAgencyWithIncludeAsync(Agency agency);
    }
}
