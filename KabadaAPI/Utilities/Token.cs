using System;
using System.Security.Claims;
using System.Text;
using KabadaAPIdao;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace KabadaAPI {
    public static class Token
    {
        public static string Generate(User user, IConfiguration config)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, user.Type.Title)
            };

            var identity = new ClaimsIdentity(claims);

            var handler = new JwtSecurityTokenHandler();
            var now = DateTime.Now;

            var token = handler.CreateToken(new SecurityTokenDescriptor()
            {
                Issuer = config["JWT:Issuer"],
                Audience = config["JWT:Issuer"],
                Subject = identity,
                NotBefore = now,
                Expires = now.AddMinutes(600),
                IssuedAt = now,
                SigningCredentials = credentials
            });

            var encodedJwt = handler.WriteToken(token);

            return encodedJwt;
        }
    }
}
