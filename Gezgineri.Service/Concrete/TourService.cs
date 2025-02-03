using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TourDtos;


namespace Gezgineri.Service.Concrete
{
    public class TourService : ITourService
    {
        private readonly ITourRepository _tourRepository;
        private readonly IMapper _mapper;

        public TourService(ITourRepository tourRepository, IMapper mapper)
        {
            _mapper = mapper;
            _tourRepository = tourRepository;
        }

        public async Task<bool> AddOrUpdateTourAsync(TourDto tourDto)
        {
            var tour = _mapper.Map<Tour>(tourDto);
            if (tourDto.ID == null)
            {
                return await _tourRepository.AddAsync(tour);
            }
            return await _tourRepository.UpdateAsync(tour);
        }

        public async Task<bool> DeleteTourAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No tour exists with the provided identifier.");
            }
            return await _tourRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TourDto?>> GetAllToursAsync()
        {
            var tours = await _tourRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TourDto>>(tours);
        }

        public async Task<TourDto?> GetTourByIdAsync(Guid id)
        {
            var tour = await _tourRepository.GetByIdAsync(id);
            if (tour == null)
            {
                throw new Exception("No tour exists with the provided identifier.");
            }
            return _mapper.Map<TourDto>(tour);
        }
    }
}
