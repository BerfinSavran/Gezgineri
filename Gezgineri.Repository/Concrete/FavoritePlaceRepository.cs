using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Gezgineri.Repository.Concrete
{
    public class FavoritePlaceRepository : GenericRepository<FavoritePlace>, IFavoritePlaceRepository
    {
        private readonly AppDbContext _context;

        public FavoritePlaceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddOrUpdateFavoritePlaceAsync(FavoritePlace place)
        {
            var existingFavorite = await _context.FavoritePlaces
                .FirstOrDefaultAsync(f => f.TravelerId == place.TravelerId && f.PlaceId == place.PlaceId);

            if (existingFavorite == null)
            {
                await _context.FavoritePlaces.AddAsync(place);
            }
            else
            {
                //if (place.ID == Guid.Empty || place.ID != existingFavorite.ID)
                //{
                //    return false;
                //}

                existingFavorite.IsFavorite = place.IsFavorite;
                _context.FavoritePlaces.Update(existingFavorite);
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CheckFavoriteAsync(Guid travelerid, Guid placeid)
        {
            return await _context.FavoritePlaces
                .AnyAsync(f => f.TravelerId == travelerid && f.PlaceId == placeid && f.IsFavorite == true);
        }

        public async Task<IEnumerable<FavoritePlace>> GetAllWithIncludeAsync()
        {
            return await _context.FavoritePlaces.Include(fp => fp.Traveler).Include(fp => fp.Place).ToListAsync();
        }

        public async Task<FavoritePlace> GetFavoritePlaceByIdWithIncludeAsync(Guid id)
        {
            return await _context.FavoritePlaces.Include(fp => fp.Traveler).Include(fp => fp.Place).FirstAsync(o => o.ID == id);
        }

        public async Task<IEnumerable<FavoritePlace>> GetFavoritePlaceByPlaceIdWithIncludeAsync(Guid placeid)
        {
            return await _context.FavoritePlaces.Where(fp => fp.PlaceId == placeid).Include(fp => fp.Traveler).Include(fp => fp.Place).ToListAsync();

        }
    }
}
