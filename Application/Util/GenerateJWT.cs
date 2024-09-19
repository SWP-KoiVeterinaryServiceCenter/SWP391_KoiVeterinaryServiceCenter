using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;
using System.IdentityModel.Tokens.Jwt;
using SecurityTokenException = Microsoft.IdentityModel.Tokens.SecurityTokenException;
namespace Application.Util
{
    public static class GenerateJWT
    {
        public static string GenerateTokenString(this Account account, string secretKey, DateTime now)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("userId", account.Id.ToString()),
                new Claim(ClaimTypes.NameIdentifier ,account.Username),
                new Claim(ClaimTypes.Role, account.Role.RoleName),
            };
            var token = new JwtSecurityToken(
               issuer: secretKey,
               audience: secretKey,
               claims,
               expires: now.AddHours(2),
               signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        public static ClaimsPrincipal? GetPrincipalFromExpiredToken(this string? token, string secretKey)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ValidateLifetime = false
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            if (tokenHandler.CanReadToken(token))
            {

                var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out Microsoft.IdentityModel.Tokens.SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            else return null;


        }
    }
}
