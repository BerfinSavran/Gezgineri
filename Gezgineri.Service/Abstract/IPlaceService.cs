using Gezgineri.Entity.Models;
using Gezgineri.Service.Dto.PlaceDtos;

namespace Gezgineri.Service.Abstract
{
    public interface IPlaceService
    {
        public Task<bool> AddOrUpdatePlaceAsync(PlaceDto placeDto);
        public Task<bool> DeletePlaceAsync(Guid id);
        public Task<IEnumerable<PlacesWithIncludeDto?>> GetAllPlacesAsync();
        public Task<PlacesWithIncludeDto?> GetPlaceByIdAsync(Guid id);
        public Task<List<PlacesWithIncludeDto?>> GetPlacesByOwnerIdWithIncludeAsync(Guid ownerid);
        public Task<IEnumerable<PlacesWithIncludeDto?>> GetPlacesByLocationWithIncludeAsync(string country, string? city = null);


    }
}

