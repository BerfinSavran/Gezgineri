
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.PlaceDtos;

using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdatePlace(PlaceDto placeDto)
        {
            var result = await _placeService.AddOrUpdatePlaceAsync(placeDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePlace(Guid id)
        {
            var result = await _placeService.DeletePlaceAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPlaces()
        {
            var result = await _placeService.GetAllPlacesAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetPlaceById(Guid id)
        {
            var result = await _placeService.GetPlaceByIdAsync(id);
            return Ok(result);
        }

    }
}
