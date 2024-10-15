﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pratik_Jwt
{
    public static class Helper
    {
        public static string GenerateJwtToken(string userId, string key,string issuer,string audience)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userId)

            };
            var token = new JwtSecurityToken(issuer:issuer,audience:audience,claims:claims,expires: DateTime.Now.AddMinutes(30),signingCredentials:credentials);

            return new JwtSecurityTokenHandler().WriteToken(token); 
        }
    }
}
