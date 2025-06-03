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
        public async Task<bool> UpdateTourAsync(Tour updatedTour)
        {
            // Mevcut turu buluyoruz
            var existingTour = await _context.Tours.FirstOrDefaultAsync(t => t.ID == updatedTour.ID);
            if (existingTour == null)
            {
                throw new Exception("Tur bulunamadı.");
            }

            // Tour'u güncelliyoruz
            existingTour.Name = updatedTour.Name;
            existingTour.Price = updatedTour.Price;
            existingTour.Capacity = updatedTour.Capacity;
            existingTour.EndDate = updatedTour.EndDate;
            existingTour.ImageUrl = updatedTour.ImageUrl;
            existingTour.Description = updatedTour.Description;
            existingTour.StartDate = updatedTour.StartDate;
            existingTour.Status = updatedTour.Status;

            // İlgili TourRoute'ları güncelliyoruz
            var tourRoutes = await _context.TourRoutes.Where(tr => tr.TourId == updatedTour.ID).ToListAsync();
            for (int i = 0; i < tourRoutes.Count; i++)
            {
                tourRoutes[i].Date = updatedTour.StartDate.AddDays(tourRoutes[i].Order - 1);
            }

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
