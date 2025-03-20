using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class TourRouteRepository : GenericRepository<TourRoute>, ITourRouteRepository
    {
        private readonly AppDbContext _context;
        public TourRouteRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TourRoute>> GetTourRoutesByTourIdAsync(Guid tourId)
        {
            return await _context.TourRoutes
                .Where(t => t.TourId == tourId)
                .ToListAsync();
        }
    }
}
