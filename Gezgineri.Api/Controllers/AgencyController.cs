using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.AgencyDtos;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgencyController : ControllerBase
    {
        private readonly IAgencyService _agencyService;

        public AgencyController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAgency([FromBody] AgencyRegisterRequestDto registerDto)
        {
            var result = await _agencyService.AddAgencyAsync(registerDto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAgencies()
        {
            var result = await _agencyService.GetAllAgencysAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetAgencyById(Guid id)
        {
            var result = await _agencyService.GetAgencyByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("memberid/{id}")]
        public async Task<ActionResult> GetAgencyByMemberId(Guid id)
        {
            var result = await _agencyService.GetAgencyByMemberIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("memberId")]
        public async Task<ActionResult> DeleteAgency(Guid id)
        {
            var result = await _agencyService.DeleteAgencyAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAgency(UpdateAgencyDto updateDto)
        {
            var result = await _agencyService.UpdateAgencyAsync(updateDto);
            return Ok(result);
        }
    }
}
