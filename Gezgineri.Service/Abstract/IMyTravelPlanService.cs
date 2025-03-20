using Gezgineri.Entity.Models;
using Gezgineri.Service.Dto.MyTravelPlanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Abstract
{
    public interface IMyTravelPlanService
    {
        public Task<bool> AddOrUpdateTravelPlanAsync(MyTravelPlanDto travelPlanDto);
        public Task<bool> DeleteTravelPlanAsync(Guid id);
        public Task<IEnumerable<MyTravelPlanDto?>> GetAllTravelPlansAsync();
        public Task<MyTravelPlanDto?> GetTravelPlanByIdAsync(Guid id);
        public Task<IEnumerable<MyTravelPlanWithIncludeDto?>> GetMyTravelPlansByTravelIdAsync(Guid myTravelId);

    }
}
