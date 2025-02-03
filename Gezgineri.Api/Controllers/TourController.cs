using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TourDtos;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;
        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateTour(TourDto tourDto)
        {
            var result = await _tourService.AddOrUpdateTourAsync(tourDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTour(Guid id)
        {
            var result = await _tourService.DeleteTourAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTours()
        {
            var result = await _tourService.GetAllToursAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTourById(Guid id)
        {
            var result = await _tourService.GetTourByIdAsync(id);
            return Ok(result);
        }

    }
}
