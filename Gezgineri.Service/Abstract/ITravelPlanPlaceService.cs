using Gezgineri.Service.Dto.TravelPlanPlaceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface ITravelPlanPlaceService
    {
        public Task<bool> AddOrUpdateTravelPlanPlaceAsync(TravelPlanPlaceDto travelPlanPlaceDto);
        public Task<bool> DeleteTravelPlanPlaceAsync(Guid id);
        public Task<IEnumerable<TravelPlanPlaceDto?>> GetAllTravelPlanPlacesAsync();
        public Task<TravelPlanPlaceDto?> GetTravelPlanPlaceByIdAsync(Guid id);
    }
}
