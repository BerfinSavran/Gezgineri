using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Repository.Concrete
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Admin> _dbset;
        public AdminRepository(AppDbContext context) : base(context)
        {
            _context = context;
            _dbset = _context.Set<Admin>();
        }

        public async Task<IEnumerable<Admin>> GetAllWithIncludeAsync()
        {
            return await _context.Admins.Include(o => o.Member).ToListAsync();
        }

        public async Task<Admin> GetAdminByIdWithIncludeAsync(Guid id)
        {
            return await _context.Admins.Include(o => o.Member).FirstAsync(o => o.ID == id);
        }

        public async Task<Admin?> GetAdminByMemberIdWithIncludeAsync(Guid memberid)
        {
            return await _context.Admins.Include(o => o.Member).FirstOrDefaultAsync(o => o.MemberId == memberid);
        }
    }
}
