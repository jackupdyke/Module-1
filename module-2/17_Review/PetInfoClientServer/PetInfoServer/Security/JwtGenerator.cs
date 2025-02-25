﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetInfoServer.Security
{
    public class JwtGenerator : ITokenGenerator
    {
        private readonly string JwtSecret;

        public JwtGenerator(string secret)
        {
            JwtSecret = secret;
        }

        public string GenerateToken(int userId, string username, string role)
        {
            Claim[] claims = new Claim[]
            {
                new Claim("sub", userId.ToString()),
                new Claim("name", username),
                new Claim(ClaimTypes.Role, role),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSecret)), SecurityAlgorithms.HmacSha256Signature),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
