using Gezgineri.Entity.Models;

namespace Gezgineri.Repository.Abstract
{
    public interface ITravelerRepository: IGenericRepository<Traveler> 
    {
        public Task<IEnumerable<Traveler>> GetAllWithIncludeAsync();
        public Task<Traveler> GetTravelerByIdWithIncludeAsync(Guid id);
        public Task<Traveler> GetTravelerByMemberIdWithIncludeAsync(Guid memberid);
        public Task<bool> UpdateTravelerWithIncludeAsync(Traveler traveler);
    }
}
