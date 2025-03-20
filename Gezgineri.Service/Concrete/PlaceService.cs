using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.PlaceDtos;

namespace Gezgineri.Service.Concrete
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _placeRepository;
        private readonly IFavoritePlaceRepository _favoritePlaceRepository;
        private readonly IMapper _mapper;

        public PlaceService(IPlaceRepository placeRepository, IMapper mapper, IFavoritePlaceRepository favoritePlaceRepository)
        {
            _mapper = mapper;
            _placeRepository = placeRepository;
            _favoritePlaceRepository = favoritePlaceRepository;
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

            // Önce bu place'e ait favori kayıtları getir
            var favoritePlaces = await _favoritePlaceRepository.GetFavoritePlaceByPlaceIdWithIncludeAsync(id);

            // Eğer favori kayıtları varsa önce onları sil
            if (favoritePlaces.Any())
            {
                foreach (var favorite in favoritePlaces)
                {
                    await _favoritePlaceRepository.DeleteAsync(favorite.ID);
                }
            }

            // Şimdi place'i silebiliriz
            return await _placeRepository.DeleteAsync(id);
        }


        public async Task<IEnumerable<PlacesWithIncludeDto?>> GetAllPlacesAsync()
        {
            var places = await _placeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PlacesWithIncludeDto>>(places);
        }

        public async Task<PlacesWithIncludeDto?> GetPlaceByIdAsync(Guid id)
        {
            var place = await _placeRepository.GetByIdWithIncludeAsync(id);
            if (place == null)
            {
                throw new Exception("No place exists with the provided identifier.");
            }
            return _mapper.Map<PlacesWithIncludeDto>(place);
        }

        public async Task<IEnumerable<PlacesWithIncludeDto?>> GetPlacesByLocationWithIncludeAsync(string country, string? city = null)
        {
            var places = await _placeRepository.GetPlacesByLocationWithIncludeAsync(country, city);
            return _mapper.Map<IEnumerable<PlacesWithIncludeDto>>(places);
        }

        public async Task<List<PlacesWithIncludeDto?>> GetPlacesByOwnerIdWithIncludeAsync(Guid ownerid)
        {
            var places = await _placeRepository.GetPlacesByOwnerIdWithIncludeAsync(ownerid);

            if (places == null)
            {
                throw new Exception("No member exists with the provided identifier.");
            }

            return _mapper.Map<List<PlacesWithIncludeDto?>>(places);
        }
    }
}
