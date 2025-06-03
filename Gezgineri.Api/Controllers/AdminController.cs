using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdmin([FromBody] AdminRegisterRequestDto registerDto)
        {
            var result = await _adminService.AddAdminAsync(registerDto);
            return Ok(result);

        }

        [HttpGet]
        public async Task<ActionResult> GetAllAdmins()
        {
            var result = await _adminService.GetAllAdminsAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetAdminById(Guid id)
        {
            var result = await _adminService.GetAdminByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("memberid/{id}")]
        public async Task<ActionResult> GetAdminByMemberId(Guid id)
        {
            var result = await _adminService.GetAdminByMemberIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("memberId")]
        public async Task<ActionResult> DeleteAdmin(Guid id)
        {
            var result = await _adminService.DeleteAdminAsync(id);
            return Ok(result);
        }
    }
}
