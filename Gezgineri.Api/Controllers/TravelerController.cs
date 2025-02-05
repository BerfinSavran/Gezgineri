using Gezgineri.Service;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TravelerDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TravelerController : ControllerBase
    {
        private readonly ITravelerService _travelerService;

        public TravelerController(ITravelerService travelerService)
        {
            _travelerService = travelerService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTraveler([FromBody] TravelerRegisterRequestDto requestDto)
        {
            var result = await _travelerService.AddTravelerAsync(requestDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTravelers()
        {
            var result = await _travelerService.GetAllTravelersAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTravelerById(Guid id)
        {
            var result = await _travelerService.GetTravelerByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("memberid/{id}")]
        public async Task<ActionResult> GetTravelerByMemberId(Guid id)
        {
            var result = await _travelerService.GetTravelerByMemberIdAsync(id);
            return Ok(result);
        }


        [HttpDelete("memberId")]
        public async Task<ActionResult> DeleteTraveler(Guid id)
        {
            var result = await _travelerService.DeleteTravelerAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTraveler(UpdateTravelerDto updateDto)
        {
            var result = await _travelerService.UpdateTravelerAsync(updateDto);
            return Ok(result);
        }
    }
}
