using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;


namespace Gezgineri.Repository.Concrete
{
    public class TourRepository : GenericRepository<Tour>, ITourRepository
    {
        private readonly AppDbContext _context;

        public TourRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Tour>> GetToursByAgencyIdWithIncludeAsync(Guid agencyid)
        {
            return await _context.Tours
                .Where(t => t.AgencyId == agencyid)
                .Include(t => t.Agency)
                .ToListAsync();
        }

        public async Task<Tour> GetByIdWithIncludeAsync(Guid id)
        {
            return await _context.Tours
                .Where(t => t.ID == id)
                .Include(t => t.Agency)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Tour>> GetAllWithIncludeAsync()
        {
            return await _context.Tours
                .Include(t => t.Agency)
                .ToListAsync();
        }

        public async Task<List<Tour>> GetToursStartingFromTodayAsync()
        {
            var today = DateTime.Today;

            return await _context.Tours
                .Where(t => t.StartDate >= today)
                .Include(t => t.Agency)
                .ToListAsync();
        }

    }
}
