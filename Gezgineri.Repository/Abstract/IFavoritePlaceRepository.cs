using Gezgineri.Entity.Models;


namespace Gezgineri.Repository.Abstract
{
    public interface IFavoritePlaceRepository : IGenericRepository<FavoritePlace>
    {
        public Task<bool> AddOrUpdateFavoritePlaceAsync(FavoritePlace place);
        public Task<IEnumerable<FavoritePlace>> GetAllWithIncludeAsync();
        public Task<FavoritePlace> GetFavoritePlaceByIdWithIncludeAsync(Guid id);
        public Task<bool> CheckFavoriteAsync(Guid travelerid, Guid placeid);
        public Task<IEnumerable<FavoritePlace>> GetFavoritePlaceByPlaceIdWithIncludeAsync(Guid placeid);

    }
}
