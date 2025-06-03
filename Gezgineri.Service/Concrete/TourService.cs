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
            return await _tourRepository.UpdateTourAsync(tour);
        }

        public async Task<bool> DeleteTourAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No tour exists with the provided identifier.");
            }
            return await _tourRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<ToursWithIncludeDto?>> GetAllWithIncludeAsync()
        {
            var tours = await _tourRepository.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<ToursWithIncludeDto>>(tours);
        }

        public async Task<ToursWithIncludeDto?> GetTourByIdWithIncludeAsync(Guid id)
        {
            var tour = await _tourRepository.GetByIdWithIncludeAsync(id);
            if (tour == null)
            {
                throw new Exception("No tour exists with the provided identifier.");
            }
            return _mapper.Map<ToursWithIncludeDto>(tour);
        }

        public async Task<List<ToursWithIncludeDto?>> GetToursByAgencyIdWithIncludeAsync(Guid agencyid)
        {
            var tours = await _tourRepository.GetToursByAgencyIdWithIncludeAsync(agencyid);

            if (tours == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<List<ToursWithIncludeDto?>>(tours);
        }
        public async Task<List<ToursWithIncludeDto?>> GetToursStartingFromTodayAsync()
        {
            var tours = await _tourRepository.GetToursStartingFromTodayAsync();

            if (tours == null || !tours.Any())
            {
                throw new Exception("No tours found starting from today.");
            }

            return _mapper.Map<List<ToursWithIncludeDto?>>(tours);
        }

    }
}
