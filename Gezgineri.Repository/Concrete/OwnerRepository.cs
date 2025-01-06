using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Owner> _dbset;
        public OwnerRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbset = _context.Set<Owner>();
        }

        public async Task<IEnumerable<Owner>> GetAllWithIncludeAsync()
        {
            return await _context.Owners.Include(o => o.Member).ToListAsync();
        }

        public async Task<Owner> GetOwnerByIdWithIncludeAsync(Guid id)
        {
            return await _context.Owners.Include(o => o.Member).FirstAsync(o => o.ID == id);
        }

        public async Task<Owner?> GetOwnerByMemberIdWithIncludeAsync(Guid memberid)
        {
            return await _context.Owners.Include(o => o.Member).FirstOrDefaultAsync(o => o.MemberId == memberid);
        }

        public async Task<bool> UpdateOwnerWithIncludeAsync(Owner owner)
        {
            var dbOwner = await _dbset.Include(o => o.Member).FirstOrDefaultAsync(o => o.ID == owner.ID);

            if (dbOwner == null)
                throw new KeyNotFoundException("Owner not found with the given ID.");

            _context.Entry(dbOwner).CurrentValues.SetValues(owner);

            if(owner.Member != null)
            {
                dbOwner.Member.FullName = owner.Member.FullName;
                dbOwner.Member.Email = owner.Member.Email;
            }

            var affectedCount = await _context.SaveChangesAsync();
            return affectedCount > 0;
        }
    }
}
