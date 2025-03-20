using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class PlaceRepository : GenericRepository<Place>, IPlaceRepository
    {
        private readonly AppDbContext _context;
        public PlaceRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Place>> GetPlacesByOwnerIdWithIncludeAsync(Guid ownerId)
        {
            return await _context.Places
                .Where(p => p.OwnerId == ownerId)
                .Include(p => p.Category)
                .Include(p => p.Owner)
                .ToListAsync();
        }

        public async Task<Place> GetByIdWithIncludeAsync(Guid id)
        {
            return await _context.Places
                .Where(p => p.ID == id)
                .Include(p => p.Category)
                .Include(p => p.Owner)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Place>> GetPlacesByLocationWithIncludeAsync(string country, string? city = null)
        {
            var placesQuery = _context.Places
                .Where(p => p.Country == country)
                .Include(p => p.Category)
                .Include(p => p.Owner!)
                .AsQueryable();

            if (!string.IsNullOrEmpty(city))
            {
                placesQuery = placesQuery.Where(p => p.City == city);
            }

            return await placesQuery.ToListAsync();
        }

    }
}
