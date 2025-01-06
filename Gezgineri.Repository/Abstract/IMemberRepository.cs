using Gezgineri.Entity.Models;

namespace Gezgineri.Repository.Abstract
{
    public interface IMemberRepository : IGenericRepository<Member>
    {
        public Task<Member?> GetMemberByEmailAsync(string email);
    }
}
