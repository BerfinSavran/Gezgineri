using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.MyTravelPlanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Concrete
{
    public class MyTravelPlanService : IMyTravelPlanService
    {
        private readonly IMyTravelPlanRepository _myTravelPlanRepository;
        private readonly IMapper _mapper;

        public MyTravelPlanService(IMyTravelPlanRepository myTravelPlanRepository, IMapper mapper)
        {
            _mapper = mapper;
            _myTravelPlanRepository = myTravelPlanRepository;
        }

        public async Task<bool> AddOrUpdateTravelPlanAsync(MyTravelPlanDto travelPlanDto)
        {
            var travelPlan = _mapper.Map<MyTravelPlan>(travelPlanDto);
            if (travelPlanDto.ID == null)
            {
                return await _myTravelPlanRepository.AddAsync(travelPlan);
            }
            return await _myTravelPlanRepository.UpdateAsync(travelPlan);
        }

        public async Task<bool> DeleteTravelPlanAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No travelPlan exists with the provided identifier.");
            }
            return await _myTravelPlanRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<MyTravelPlanDto?>> GetAllTravelPlansAsync()
        {
            var travelPlans = await _myTravelPlanRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<MyTravelPlanDto>>(travelPlans);
        }

        public async Task<IEnumerable<MyTravelPlanWithIncludeDto?>> GetMyTravelPlansByTravelIdAsync(Guid myTravelId)
        {
            var travelPlans = await _myTravelPlanRepository.GetMyTravelPlansByTravelIdAsync(myTravelId);
            return _mapper.Map<IEnumerable<MyTravelPlanWithIncludeDto>>(travelPlans);

        }


        public async Task<MyTravelPlanDto?> GetTravelPlanByIdAsync(Guid id)
        {
            var travelPlan = await _myTravelPlanRepository.GetByIdAsync(id);
            if (travelPlan == null)
            {
                throw new Exception("No travelPlan exists with the provided identifier.");
            }
            return _mapper.Map<MyTravelPlanDto>(travelPlan);
        }
    }
}
