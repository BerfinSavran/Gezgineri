using Gezgineri.Service.Dto.TravelPlanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface ITravelPlanService
    {
        public Task<bool> AddOrUpdateTravelPlanAsync(TravelPlanDto travelPlanDto);
        public Task<bool> DeleteTravelPlanAsync(Guid id);
        public Task<IEnumerable<TravelPlanDto?>> GetAllTravelPlansAsync();
        public Task<TravelPlanDto?> GetTravelPlanByIdAsync(Guid id);
    }
}
