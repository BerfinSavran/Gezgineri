using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.MyTravelPlanDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MyTravelPlanController : ControllerBase
    {
        private readonly IMyTravelPlanService _myTravelPlanRepository;
        public MyTravelPlanController(IMyTravelPlanService myTravelPlanRepository)
        {
            _myTravelPlanRepository = myTravelPlanRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateTravelPlan(MyTravelPlanDto travelPlanDto)
        {
            var result = await _myTravelPlanRepository.AddOrUpdateTravelPlanAsync(travelPlanDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTravelPlan(Guid id)
        {
            var result = await _myTravelPlanRepository.DeleteTravelPlanAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTravelPlans()
        {
            var result = await _myTravelPlanRepository.GetAllTravelPlansAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTravelPlanById(Guid id)
        {
            var result = await _myTravelPlanRepository.GetTravelPlanByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("travelId/{myTravelId}")]
        public async Task<ActionResult> GetTravelPlansByTravelId(Guid myTravelId)
        {
            var result = await _myTravelPlanRepository.GetMyTravelPlansByTravelIdAsync(myTravelId);
            return Ok(result);
        }
    }
}
