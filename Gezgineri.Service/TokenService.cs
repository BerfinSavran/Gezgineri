using Gezgineri.Entity.Types;
using Gezgineri.Service.Dto.JwtSettingsDto;
using Gezgineri.Service.Dto.MemberDtos;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Gezgineri.Service
{
    public class TokenService
    {
        private readonly JwtSettings _jwtSettings;

        public TokenService(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public MemberDto DecryptToken(string token)
        {
            if (_jwtSettings.Key == null) throw new Exception("JWT key is NULL");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

            if (jwtToken == null) return null;

            var memberId = Guid.Parse(jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value);
            var email = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var role = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            return new MemberDto
            {
                ID = memberId,
                Email = email,
                Role = (EnumRole)Enum.Parse(typeof(EnumRole), role)
            };
        }
    }

}
