using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TravelPlanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Concrete
{
    public class TravelPlanService : ITravelPlanService
    {
        private readonly ITravelPlanRepository _travelPlanRepository;
        private readonly IMapper _mapper;

        public TravelPlanService(ITravelPlanRepository travelPlanRepository, IMapper mapper)
        {
            _mapper = mapper;
            _travelPlanRepository = travelPlanRepository;
        }

        public async Task<bool> AddOrUpdateTravelPlanAsync(TravelPlanDto travelPlanDto)
        {
            var travelPlan = _mapper.Map<TravelPlan>(travelPlanDto);
            if (travelPlanDto.ID == null)
            {
                return await _travelPlanRepository.AddAsync(travelPlan);
            }
            return await _travelPlanRepository.UpdateAsync(travelPlan);
        }

        public async Task<bool> DeleteTravelPlanAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No travelPlan exists with the provided identifier.");
            }
            return await _travelPlanRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TravelPlanDto?>> GetAllTravelPlansAsync()
        {
            var travelPlans = await _travelPlanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TravelPlanDto>>(travelPlans);
        }

        public async Task<TravelPlanDto?> GetTravelPlanByIdAsync(Guid id)
        {
            var travelPlan = await _travelPlanRepository.GetByIdAsync(id);
            if (travelPlan == null)
            {
                throw new Exception("No travelPlan exists with the provided identifier.");
            }
            return _mapper.Map<TravelPlanDto>(travelPlan);
        }
    }
}
