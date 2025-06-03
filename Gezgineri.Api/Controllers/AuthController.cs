using AutoMapper;
using Gezgineri.Common;
using Gezgineri.Entity.Types;
using Gezgineri.Service.Abstract;
using Gezgineri.Service.Dto.JwtSettingsDto;
using Gezgineri.Service.Dto.LoginDtos;
using Gezgineri.Service.Dto.MemberDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gezgineri.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;

        public AuthController (IOptions<JwtSettings> jwtSettings, IMemberService memberService, IMapper mapper)
        {
            _jwtSettings = jwtSettings.Value;
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
                return Unauthorized();
            }

            var token = CreateToken(member);

            var response = new LoginResponseDTO
            {
                Token = token
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult> DecodeToken(string token)
        {
            if (_jwtSettings.Key == null) throw new Exception("JWT key is NULL");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null) return null;

            var memberId = Guid.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            var response =  new MemberDto
            {
                ID = memberId,
                Email = email,
                Role = (EnumRole)Enum.Parse(typeof(EnumRole), role)
            };
            return Ok(response);
        }

        private string CreateToken(MemberDto member)
        {
            if (_jwtSettings.Key == null) throw new Exception("JWT key is NULL");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, member.ID.ToString()),
                new Claim(ClaimTypes.Email, member.Email),
                new Claim(ClaimTypes.Role, member.Role.ToString()),
            };

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credentials
            );


            return new JwtSecurityTokenHandler().WriteToken(token);
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
