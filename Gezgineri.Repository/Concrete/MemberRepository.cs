
using Gezgineri.Data;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Gezgineri.Repository.Concrete
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        private readonly AppDbContext _context;
        public MemberRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Member?> GetMemberByEmailAsync(string email)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.Email == email);
        }
    }
}
