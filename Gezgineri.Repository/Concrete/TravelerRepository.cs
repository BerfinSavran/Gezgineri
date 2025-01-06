using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class TravelerRepository : GenericRepository<Traveler>, ITravelerRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Traveler> _dbSet;

        public TravelerRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Traveler>();
        }

        public async Task<IEnumerable<Traveler>> GetAllWithIncludeAsync()
        {
            return await _context.Travelers.Include(t => t.Member).ToListAsync();
        }

        public async Task<Traveler> GetTravelerByIdWithIncludeAsync(Guid id)
        {
            return await _context.Travelers.Include(t => t.Member).FirstAsync(t => t.ID == id);
        }

        public async Task<Traveler?> GetTravelerByMemberIdWithIncludeAsync(Guid memberid)
        {
            return await _context.Travelers.Include(t => t.Member).FirstOrDefaultAsync(t => t.MemberId == memberid);
        }

        public async Task<bool> UpdateTravelerWithIncludeAsync(Traveler traveler)
        {
            var dbTraveler = await _dbSet.Include(t => t.Member).FirstOrDefaultAsync(t => t.ID == traveler.ID);

            if (dbTraveler == null)
                throw new KeyNotFoundException("Traveler not found with the given ID.");

            // Traveler alanlarını güncelle
            _context.Entry(dbTraveler).CurrentValues.SetValues(traveler);

            // İlişkili Member alanlarını güncelle
            if (traveler.Member != null)
            {
                dbTraveler.Member.FullName = traveler.Member.FullName;
                dbTraveler.Member.Email = traveler.Member.Email;
            }

            // Değişiklikleri kaydet
            var affectedRowCount = await _context.SaveChangesAsync();
            return affectedRowCount > 0;
        }

    }
}
