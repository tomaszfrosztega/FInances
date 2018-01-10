using Finances.Infrastructure.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finances.Infrastructure.DTO;
using Finances.Infrastructure.Settings;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Finances.Infrastructure.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Finances.Infrastructure.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtSettings;

        public JwtHandler(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public JwtDTO CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role,role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString(), ClaimValueTypes.Integer64)
            };

            var expires = now.AddMinutes(_jwtSettings.ExpiryMinutes);
            var signingCredensials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key)),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials : signingCredensials
                );
            string token; 
            try
            { 
                token = new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            catch (Exception ex)
            {
                token = ex.Message;
            }
            return new JwtDTO
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
    }
}
