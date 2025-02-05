using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TravelPlanDtos;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TravelPlanController : ControllerBase
    {
        private readonly ITravelPlanService _travelPlanService;
        public TravelPlanController(ITravelPlanService travelPlanService)
        {
            _travelPlanService = travelPlanService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateTravelPlan(TravelPlanDto travelPlanDto)
        {
            var result = await _travelPlanService.AddOrUpdateTravelPlanAsync(travelPlanDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTravelPlan(Guid id)
        {
            var result = await _travelPlanService.DeleteTravelPlanAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTravelPlans()
        {
            var result = await _travelPlanService.GetAllTravelPlansAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTravelPlanById(Guid id)
        {
            var result = await _travelPlanService.GetTravelPlanByIdAsync(id);
            return Ok(result);
        }
    }
}
