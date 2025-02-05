using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.MyTravelDtos;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class MyTravelController : ControllerBase
    {
        private readonly IMyTravelService _myTravelService;
        public MyTravelController(IMyTravelService myTravelService)
        {
            _myTravelService = myTravelService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateMyTravel(MyTravelDto myTravelDto)
        {
            var result = await _myTravelService.AddOrUpdateMyTravelAsync(myTravelDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMyTravel(Guid id)
        {
            var result = await _myTravelService.DeleteMyTravelAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMyTravels()
        {
            var result = await _myTravelService.GetAllMyTravelsAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetMyTravelById(Guid id)
        {
            var result = await _myTravelService.GetMyTravelByIdAsync(id);
            return Ok(result);
        }
    }
}
