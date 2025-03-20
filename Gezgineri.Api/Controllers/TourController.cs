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
        private readonly IAgencyService _agencyService;
        public TourController(ITourService tourService, IAgencyService agencyService)
        {
            _tourService = tourService;
            _agencyService = agencyService;
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
        public async Task<ActionResult> GetAllWithInclude()
        {
            var result = await _tourService.GetAllWithIncludeAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTourByIdWithInclude(Guid id)
        {
            var result = await _tourService.GetTourByIdWithIncludeAsync(id);
            return Ok(result);
        }

        [HttpGet("agencyid")]
        public async Task<ActionResult> GetToursByAgencyIdWithInclude(Guid agencyid)
        {
            var result = await _tourService.GetToursByAgencyIdWithIncludeAsync(agencyid);
            return Ok(result);
        }

        [HttpGet("GetToursStartingFromToday")]
        public async Task<ActionResult> GetToursStartingFromToday()
        {
            var result = await _tourService.GetToursStartingFromTodayAsync();
            return Ok(result);
        }
    }
}
