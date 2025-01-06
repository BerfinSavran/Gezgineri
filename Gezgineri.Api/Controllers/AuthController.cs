using AutoMapper;
using Gezgineri.Common;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.LoginDtos;
using Gezgineri.Service.Dto.MemberDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gezgineri.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public AuthController (IMemberService memberService, IMapper mapper)
        {
            _memberService = memberService;
            _mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequest)
        {
            var member = await AuthenticationControlAsync(loginRequest);
            if (member == null)
            {
                return NotFound();
            }

            var response = new LoginResponseDTO
            {
                Member = member, // token gelecek
            };

            return Ok(response);
        }

        private async Task<MemberDto?> AuthenticationControlAsync(LoginRequestDTO loginRequest)
        {
            var member = await _memberService.GetMemberByEmailAsync(loginRequest.Email);
            if (member == null || member.Password != Encrypter.EncryptString(loginRequest.Password))
            {
                throw new Exception("Authentication Failed!!");
            }
            return member;
        }

    }
}
