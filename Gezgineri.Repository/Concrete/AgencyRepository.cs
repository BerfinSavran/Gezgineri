using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class AgencyRepository : GenericRepository<Agency>, IAgencyRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Agency> _dbSet;
        public AgencyRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbSet = _context.Set<Agency>();
        }

        public async Task<Agency> GetAgencyByIdWithIncludeAsync(Guid id)
        {
            return await _context.Agencies.Include(a => a.Member).FirstAsync(a => a.ID == id);
        }

        public async Task<Agency?> GetAgencyByMemberIdWithIncludeAsync(Guid memberid)
        {
            return await _context.Agencies.Include(a => a.Member).FirstOrDefaultAsync(a => a.MemberId == memberid);
        }

        public async Task<IEnumerable<Agency>> GetAllWithIncludeAsync()
        {
            return await _context.Agencies.Include(a => a.Member).ToListAsync();
        }

        public async Task<bool> UpdateAgencyWithIncludeAsync(Agency agency)
        {
            var dbAgency = await _dbSet.Include(a => a.Member).FirstOrDefaultAsync(a => a.ID == agency.ID);

            if (dbAgency == null)
                throw new KeyNotFoundException("Agency not found with the given ID.");

            _context.Entry(dbAgency).CurrentValues.SetValues(agency);

            if(agency.Member != null)
            {
                dbAgency.Member.FullName = agency.Member.FullName;
                dbAgency.Member.Email = agency.Member.Email;
            }

            var affectedCount = await _context.SaveChangesAsync();
            return affectedCount > 0;
        }
    }
}
