using AutoMapper;
using Gezgineri.Entity.Models;
using Gezgineri.Repository.Abstract;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.FavoritePlaceDtos;


namespace Gezgineri.Service.Concrete
{
    public class FavoritePlaceService : IFavoritePlaceService
    {
        private readonly IFavoritePlaceRepository _favoritePlaceRepository;
        private readonly IMapper _mapper;

        public FavoritePlaceService(IFavoritePlaceRepository favoritePlaceRepository, IMapper mapper)
        {
            _mapper = mapper;
            _favoritePlaceRepository = favoritePlaceRepository;
        }

        public async Task<bool> AddOrUpdateFavoritePlaceAsync(FavoritePlaceDto favoritePlaceDto)
        {
            var place = _mapper.Map<FavoritePlace>(favoritePlaceDto);
            return await _favoritePlaceRepository.AddOrUpdateFavoritePlaceAsync(place);
        }

        public async Task<bool> CheckFavoriteAsync(Guid travelerid, Guid placeid)
        {
            if(travelerid == Guid.Empty || placeid == Guid.Empty)
            {
                throw new Exception("No place or traveler exists with the provided identifier.");
            }
            return await _favoritePlaceRepository.CheckFavoriteAsync(travelerid, placeid);
        }

        public async Task<bool> DeleteFavoritePlaceAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                throw new Exception("No place exists with the provided identifier.");
            }
            return await _favoritePlaceRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<FavoritePlaceDto?>> GetAllFavoritePlacesAsync()
        {
            var places = await _favoritePlaceRepository.GetAllWithIncludeAsync();
            return _mapper.Map<IEnumerable<FavoritePlaceDto>>(places);
        }

        public async Task<FavoritePlaceDto?> GetFavoritePlaceByIdAsync(Guid id)
        {
            var place = await _favoritePlaceRepository.GetFavoritePlaceByIdWithIncludeAsync(id);
            if (place == null)
            {
                throw new Exception("No place exists with the provided identifier.");
            }
            return _mapper.Map<FavoritePlaceDto>(place);
        }

        public async Task<IEnumerable<FavoritePlaceDto?>> GetFavoritePlaceByPlaceIdAsync(Guid id)
        {
            var place = await _favoritePlaceRepository.GetFavoritePlaceByPlaceIdWithIncludeAsync(id);
            if (place == null)
            {
                throw new Exception("No place exists with the provided identifier.");
            }
            return _mapper.Map<IEnumerable<FavoritePlaceDto>>(place);
        }
    }
}
