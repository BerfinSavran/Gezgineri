using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TourRouteDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gezgineri.Service.Concrete
{
    public class TourRouteService : ITourRouteService
    {
        private readonly ITourRouteRepository _tourRouteRepository;
        private readonly IMapper _mapper;

        public TourRouteService(ITourRouteRepository tourRouteRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tourRouteRepository = tourRouteRepository;
        }

        public async Task<bool> AddOrUpdateTourRouteAsync(TourRouteDto tourRouteDto)
        {
            var tourRoute = _mapper.Map<TourRoute>(tourRouteDto);
            if (tourRouteDto.ID == null)
            {
                return await _tourRouteRepository.AddAsync(tourRoute);
            }
            return await _tourRouteRepository.UpdateAsync(tourRoute);
        }

        public async Task<bool> DeleteTourRouteAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No tourRoute exists with the provided identifier.");
            }
            return await _tourRouteRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TourRouteDto?>> GetAllTourRoutesAsync()
        {
            var tourRoutes = await _tourRouteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TourRouteDto>>(tourRoutes);
        }

        public async Task<TourRouteDto?> GetTourRouteByIdAsync(Guid id)
        {
            var tourRoute = await _tourRouteRepository.GetByIdAsync(id);
            if (tourRoute == null)
            {
                throw new Exception("No tourRoute exists with the provided identifier.");
            }
            return _mapper.Map<TourRouteDto>(tourRoute);
        }
    }
}
