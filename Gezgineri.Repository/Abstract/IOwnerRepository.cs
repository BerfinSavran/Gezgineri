using Gezgineri.Entity.Models;


namespace Gezgineri.Repository.Abstract
{
    public interface IOwnerRepository : IGenericRepository<Owner>
    {
        public Task<IEnumerable<Owner>> GetAllWithIncludeAsync();
        public Task<Owner> GetOwnerByIdWithIncludeAsync(Guid id);
        public Task<Owner> GetOwnerByMemberIdWithIncludeAsync(Guid memberid);
        public Task<bool> UpdateOwnerWithIncludeAsync(Owner owner);
    }
}
