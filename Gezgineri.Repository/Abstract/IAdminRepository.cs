using Gezgineri.Entity.Models;


namespace Gezgineri.Repository.Abstract
{
    public interface IAdminRepository : IGenericRepository<Admin>
    {
        public Task<IEnumerable<Admin>> GetAllWithIncludeAsync();
        public Task<Admin> GetAdminByIdWithIncludeAsync(Guid id);
        public Task<Admin> GetAdminByMemberIdWithIncludeAsync(Guid memberid);
    }
}
