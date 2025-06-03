using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.PlaceDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;
        private readonly IOwnerService _ownerService;
        public PlaceController(IPlaceService placeService, IOwnerService ownerService)
        {
            _placeService = placeService;
            _ownerService = ownerService;
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

        [HttpGet("location/{country}")]
        public async Task<ActionResult> GetPlacesByLocationWithInclude(string country, [FromQuery] string? city = null)
        {
            var result = await _placeService.GetPlacesByLocationWithIncludeAsync(country, city);
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetPlaceById(Guid id)
        {
            var result = await _placeService.GetPlaceByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("ownerid")]
        public async Task<ActionResult> GetPlacesByOwnerIdWithInclude(Guid ownerid)
        {
            
            var result = await _placeService.GetPlacesByOwnerIdWithIncludeAsync(ownerid);
            return Ok(result);
        }
    }
}
