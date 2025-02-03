using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.PlaceDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Concrete
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IMapper _mapper;

        public PlaceService(IPlaceRepository placeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _placeRepository = placeRepository;
        }

        public async Task<bool> AddOrUpdatePlaceAsync(PlaceDto placeDto)
        {
            var place = _mapper.Map<Place>(placeDto);
            if (placeDto.ID == null)
            {
                return await _placeRepository.AddAsync(place);
            }
            return await _placeRepository.UpdateAsync(place);
        }

        public async Task<bool> DeletePlaceAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No place exists with the provided identifier.");
            }
            return await _placeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PlaceDto?>> GetAllPlacesAsync()
        {
            var places = await _placeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlaceDto>>(places);
        }

        public async Task<PlaceDto?> GetPlaceByIdAsync(Guid id)
        {
            var place = await _placeRepository.GetByIdAsync(id);
            if (place == null)
            {
                throw new Exception("No place exists with the provided identifier.");
            }
            return _mapper.Map<PlaceDto>(place);
        }
    }
}
