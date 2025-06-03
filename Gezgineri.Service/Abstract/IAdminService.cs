using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface IAdminService
    {
        public Task<bool> AddAdminAsync(AdminRegisterRequestDto registerDto);
        public Task<bool> DeleteAdminAsync(Guid id);
        public Task<IEnumerable<AdminDto?>> GetAllAdminsAsync();
        public Task<AdminDto?> GetAdminByIdAsync(Guid id);
        public Task<AdminDto?> GetAdminByMemberIdAsync(Guid memberid);
    }
}
