using Core.IRepo;
using Core.Models.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey key;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            var secretKey = _configuration.GetSection("JwtSetting:JwtKey").Value;
            key = new SymmetricSecurityKey(Encoding.UTF8
                   .GetBytes(secretKey));
        }
        public string CreateToken(AppUser user)
        {
           
            var claims = new Claim[]
            {
                 new Claim(JwtRegisteredClaimNames.Email,user.Email),
                 new Claim(JwtRegisteredClaimNames.GivenName, user.DisplayName)
            };

            var signingCredintiels = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature
                );

            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signingCredintiels,
                Issuer = _configuration.GetSection("JwtSetting:Issuer").Value
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
