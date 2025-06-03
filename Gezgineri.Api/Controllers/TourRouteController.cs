using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.TourRouteDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TourRouteController : Controller
    {
        private readonly ITourRouteService _tourRouteService;
        public TourRouteController(ITourRouteService tourRouteService)
        {
            _tourRouteService = tourRouteService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateTourRoute(TourRouteDto tourRouteDto)
        {
            var result = await _tourRouteService.AddOrUpdateTourRouteAsync(tourRouteDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteTourRoute(Guid id)
        {
            var result = await _tourRouteService.DeleteTourRouteAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTourRoutes()
        {
            var result = await _tourRouteService.GetAllTourRoutesAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTourRouteById(Guid id)
        {
            var result = await _tourRouteService.GetTourRouteByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("tourid/{tourid}")]
        public async Task<ActionResult> GetTourRoutesByTourId(Guid tourid)
        {
            var result = await _tourRouteService.GetTourRoutesByTourIdAsync(tourid);
            return Ok(result);
        }
    }
}
