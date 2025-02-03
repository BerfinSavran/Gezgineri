using Gezgineri.Service;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Concrete;
using Gezgineri.Service.Dto.OwnerDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;
        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateOwner([FromBody] OwnerRegisterRequestDto registerDto)
        {
            var result = await _ownerService.AddOwnerAsync(registerDto);
            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult> GetAllOwners()
        {
            var result = await _ownerService.GetAllOwnersAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetOwnerById(Guid id)
        {
            var result = await _ownerService.GetOwnerByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("memberid/{id}")]
        public async Task<ActionResult> GetOwnerByMemberId(Guid id)
        {
            var result = await _ownerService.GetOwnerByMemberIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("memberId")]
        public async Task<ActionResult> DeleteOwner(Guid id)
        {
            var result = await _ownerService.DeleteOwnerAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateOwner(UpdateOwnerDto updateDto)
        {
            var result = await _ownerService.UpdateOwnerAsync(updateDto);
            return Ok(result);
        }
    }
}
