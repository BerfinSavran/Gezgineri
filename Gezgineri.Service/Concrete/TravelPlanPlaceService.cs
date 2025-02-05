using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TravelPlanPlaceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Concrete
{
    public class TravelPlanPlaceService : ITravelPlanPlaceService
    {
        private readonly ITravelPlanPlaceRepository _travelPlanPlaceRepository;
        private readonly IMapper _mapper;

        public TravelPlanPlaceService(ITravelPlanPlaceRepository travelPlanPlaceRepository, IMapper mapper)
        {
            _mapper = mapper;
            _travelPlanPlaceRepository = travelPlanPlaceRepository;
        }

        public async Task<bool> AddOrUpdateTravelPlanPlaceAsync(TravelPlanPlaceDto travelPlanPlaceDto)
        {
            var travelPlanPlace = _mapper.Map<TravelPlanPlace>(travelPlanPlaceDto);
            if (travelPlanPlaceDto.ID == null)
            {
                return await _travelPlanPlaceRepository.AddAsync(travelPlanPlace);
            }
            return await _travelPlanPlaceRepository.UpdateAsync(travelPlanPlace);
        }

        public async Task<bool> DeleteTravelPlanPlaceAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No travelPlanPlace exists with the provided identifier.");
            }
            return await _travelPlanPlaceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TravelPlanPlaceDto?>> GetAllTravelPlanPlacesAsync()
        {
            var travelPlanPlaces = await _travelPlanPlaceRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TravelPlanPlaceDto>>(travelPlanPlaces);
        }

        public async Task<TravelPlanPlaceDto?> GetTravelPlanPlaceByIdAsync(Guid id)
        {
            var travelPlanPlace = await _travelPlanPlaceRepository.GetByIdAsync(id);
            if (travelPlanPlace == null)
            {
                throw new Exception("No travelPlanPlace exists with the provided identifier.");
            }
            return _mapper.Map<TravelPlanPlaceDto>(travelPlanPlace);
        }
    }
}
