using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TravelPlanPlaceDtos;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TravelPlanPlaceController : ControllerBase
    {
        private readonly ITravelPlanPlaceService _travelPlanPlaceService;
        public TravelPlanPlaceController(ITravelPlanPlaceService travelPlanPlaceService)
        {
            _travelPlanPlaceService = travelPlanPlaceService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateTravelPlanPlace(TravelPlanPlaceDto travelPlanPlaceDto)
        {
            var result = await _travelPlanPlaceService.AddOrUpdateTravelPlanPlaceAsync(travelPlanPlaceDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTravelPlanPlace(Guid id)
        {
            var result = await _travelPlanPlaceService.DeleteTravelPlanPlaceAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTravelPlanPlaces()
        {
            var result = await _travelPlanPlaceService.GetAllTravelPlanPlacesAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTravelPlanPlaceById(Guid id)
        {
            var result = await _travelPlanPlaceService.GetTravelPlanPlaceByIdAsync(id);
            return Ok(result);
        }
    }
}
