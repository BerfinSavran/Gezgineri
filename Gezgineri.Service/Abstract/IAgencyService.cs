

using Gezgineri.Service.Dto.AgencyDtos;

namespace Gezgineri.Service.Abstract
{
    public interface IAgencyService 
    {
        public Task<bool> AddAgencyAsync(AgencyRegisterRequestDto registerDto);
        public Task<bool> UpdateAgencyAsync(UpdateAgencyDto updateAgencyDto);
        public Task<bool> DeleteAgencyAsync(Guid id);
        public Task<IEnumerable<AgencyDto?>> GetAllAgencysAsync();
        public Task<AgencyDto?> GetAgencyByIdAsync(Guid id);
        public Task<AgencyDto?> GetAgencyByMemberIdAsync(Guid memberid);

    }
}
