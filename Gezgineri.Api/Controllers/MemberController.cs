using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.MemberDtos;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdateMember(MemberDto memberDto)
        {
            var result = await _memberService.AddOrUpdateMemberAsync(memberDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMember(Guid id)
        {
            var result = await _memberService.DeleteMemberAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllMembers()
        {
            var result = await _memberService.GetAllMembersAsync();
            return Ok(result);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetMemberById(Guid id)
        {
            var result = await _memberService.GetMemberByIdAsync(id);
            return Ok(result);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult> GetMemberByEmail(string email)
        {
            var result = await _memberService.GetMemberByEmailAsync(email);
            return Ok(result);
        }
    }
}
