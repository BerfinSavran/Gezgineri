using Gezgineri.Service.Dto.FavoritePlaceDtos;
using Gezgineri.Service.Dto.PlaceDtos;

namespace Gezgineri.Service.Abstract
{
    public interface IFavoritePlaceService
    {
        public Task<bool> AddOrUpdateFavoritePlaceAsync(FavoritePlaceDto favoriteplaceDto);
        public Task<bool> DeleteFavoritePlaceAsync(Guid id);
        public Task<IEnumerable<FavoritePlaceDto?>> GetAllFavoritePlacesAsync();
        public Task<FavoritePlaceDto?> GetFavoritePlaceByIdAsync(Guid id);
        public Task<bool> CheckFavoriteAsync(Guid travelerid, Guid placeid);
        public Task<IEnumerable<FavoritePlaceDto?>> GetFavoritePlaceByPlaceIdAsync(Guid id);

    }
}
