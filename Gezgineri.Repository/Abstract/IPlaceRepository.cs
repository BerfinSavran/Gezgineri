using Gezgineri.Entity.Models;

namespace Gezgineri.Repository.Abstract
{
    public interface IPlaceRepository :  IGenericRepository<Place>
    {
        public Task<List<Place>> GetPlacesByOwnerIdWithIncludeAsync(Guid ownerid);
        public Task<Place> GetByIdWithIncludeAsync(Guid id);
        public Task<IEnumerable<Place>> GetPlacesByLocationWithIncludeAsync(string country, string? city = null);

    }
}
