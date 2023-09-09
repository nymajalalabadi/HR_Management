﻿using HR.Management.Identity.Models;
using HR_Management.Application.Constants;
using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HR.Management.Identity.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly JwtSettings _jwtSettings;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AuthService(UserManager<ApplicationUser> userManager,
			IOptions<JwtSettings> jwtSettings,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_jwtSettings = jwtSettings.Value;
			_signInManager = signInManager;
		}

		#region register

		public async Task<RegistrationResponse> Register(RegisterationRequest request)
		{
			var existingUser = await _userManager.FindByNameAsync(request.UserName);
			if (existingUser != null)
			{
				throw new Exception($"user name '{request.UserName}' already exists.");
			}

			var user = new ApplicationUser
			{
				Email = request.Email,
				FirstName = request.FirstName,
				LastName = request.LastName,
				UserName = request.UserName,
				EmailConfirmed = true
			};


			var existingEmail = await _userManager.FindByEmailAsync(request.Email);
			if (existingEmail == null)
			{
				var result = await _userManager.CreateAsync(user, request.Password);

				if (result.Succeeded)
				{
					await _userManager.AddToRoleAsync(user, "Employee");
					return new RegistrationResponse() { UserId = user.Id };
				}
				else
				{
					throw new Exception($"{result.Errors}");
				}
			}
			else
			{
				throw new Exception($"Email '{request.Email}' already exists.");
			}

		}

		#endregion

		#region login

		public Task<AuthResponse> Login(AuthRequest authRequest)
		{
			throw new NotImplementedException();
		}

		#endregion

		private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
		{
			var userClaim = await _userManager.GetClaimsAsync(user);

			var roles = await _userManager.GetRolesAsync(user);

			var roleClaims = new List<Claim>();

			for (int i = 0; i < roles.Count; i++)
			{
				roleClaims.Add(new Claim(ClaimTypes.Role, roles[i]));
			}

			var claims = new[]
		   {
				new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email,user.Email),
				new Claim(CustomClaimTypes.Uid,user.Id)
			}
		   .Union(userClaim)
		   .Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken
				(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
				signingCredentials: signingCredentials
				);

			return jwtSecurityToken;
		}
	}
}
