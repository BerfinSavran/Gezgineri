using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.FavoritePlaceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavoritePlaceController : ControllerBase
    {
        private readonly IFavoritePlaceService _favoritePlaceService;
        public FavoritePlaceController(IFavoritePlaceService favoritePlaceService)
        {
            _favoritePlaceService = favoritePlaceService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateFavoritePlace(FavoritePlaceDto favoritePlaceDto)
        {
            var result = await _favoritePlaceService.AddOrUpdateFavoritePlaceAsync(favoritePlaceDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteFavoritePlace(Guid id)
        {
            var result = await _favoritePlaceService.DeleteFavoritePlaceAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllFavoritePlaces()
        {
            var result = await _favoritePlaceService.GetAllFavoritePlacesAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetFavoritePlaceById(Guid id)
        {
            var result = await _favoritePlaceService.GetFavoritePlaceByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("placeid/{placeid}")]
        public async Task<ActionResult> GetFavoritePlaceByPlaceId(Guid placeid)
        {
            var result = await _favoritePlaceService.GetFavoritePlaceByIdAsync(placeid);
            return Ok(result);
        }

        [HttpGet("CheckFavorite")]
        public async Task<ActionResult> CheckFavorite(Guid travelerid, Guid placeid)
        {
            var result = await _favoritePlaceService.CheckFavoriteAsync(travelerid, placeid);
            return Ok(result);
        }
    }
}
