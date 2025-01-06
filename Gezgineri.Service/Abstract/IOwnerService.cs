using Gezgineri.Service.Dto.OwnerDtos;


namespace Gezgineri.Service.Abstract
{
    public interface IOwnerService
    {
        public Task<bool> AddOwnerAsync(OwnerRegisterRequestDto registerDto);
        public Task<bool> UpdateOwnerAsync(UpdateOwnerDto updateOwnerDto);
        public Task<bool> DeleteOwnerAsync(Guid id);
        public Task<IEnumerable<OwnerDto?>> GetAllOwnersAsync();
        public Task<OwnerDto?> GetOwnerByIdAsync(Guid id);
        public Task<OwnerDto?> GetOwnerByMemberIdAsync(Guid memberid);
    }
}
