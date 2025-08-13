using Azure.Core;
using ClinicalManagement.Application.Abstractions.Services.AuthServices;
using ClinicalManagement.Application.Dtos.AuthDtos;
using ClinicalManagement.Domain.Entities;
using ClinicalManagement.Domain.Interfaces;
using ClinicalManagement.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicalManagement.Infrastructure.Services.AuthServices
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public AuthResponse GenerateTokens(UserModel user,List<string> roles)
        {
            List<Claim> userClaims = new List<Claim>();
            userClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            userClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            userClaims.Add(new Claim(ClaimTypes.Email, user.Email));
            userClaims.Add(new Claim(ClaimTypes.Name, user.UserName));
           // var role =  userManager.GetRolesAsync(user);

            var symmetric = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecritKey"]));

            SigningCredentials signing = new SigningCredentials(symmetric, SecurityAlgorithms.HmacSha256);
            foreach (var item in roles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, item));
            }

            JwtSecurityToken jwtSecurity = new JwtSecurityToken(
                    audience: configuration["JWT:AudienceIP"],
                    issuer: configuration["JWT:IssuerIP"],
                    expires: DateTime.Now.AddDays(1),
                    claims: userClaims,
                    signingCredentials: signing
                );
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurity);

           
            return new AuthResponse
            {
                RefreshToken ="",
                AccessToken = accessToken,
                ExpiresAt = DateTime.Now.AddDays(1)

            };
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
       
    }
}
