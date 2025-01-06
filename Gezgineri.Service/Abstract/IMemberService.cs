
using Gezgineri.Service.Dto.MemberDtos;

namespace Gezgineri.Service.Abstract
{
    public interface IMemberService
    {
        public Task<bool> AddOrUpdateMemberAsync(MemberDto memberDto);
        public Task<bool> DeleteMemberAsync(Guid id);
        public Task<IEnumerable<MemberDto?>> GetAllMembersAsync();
        public Task<MemberDto?> GetMemberByIdAsync(Guid id);
        public Task<MemberDto?> GetMemberByEmailAsync(string email);
    }
}
