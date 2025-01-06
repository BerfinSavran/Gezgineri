using Gezgineri.Service.Dto.TravelerDtos;


namespace Gezgineri.Service.Abstract
{
    public interface ITravelerService 
    {
        public Task<bool> AddTravelerAsync(TravelerRegisterRequestDto registerDto);
        public Task<bool> UpdateTravelerAsync(UpdateTravelerDto updateTravelerDto);
        public Task<bool> DeleteTravelerAsync(Guid id);
        public Task<IEnumerable<TravelerDto?>> GetAllTravelersAsync();
        public Task<TravelerDto?> GetTravelerByIdAsync(Guid id);
        public Task<TravelerDto?> GetTravelerByMemberIdAsync(Guid memberid);
    }
}
