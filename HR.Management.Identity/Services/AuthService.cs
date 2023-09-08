using HR.Management.Identity.Models;
using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Management.Identity.Services
{
	public class AuthService : IAuthService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly IOptions<JwtSettings> _jwtSettings;
		private readonly SignInManager<ApplicationUser> _signInManager;

		public AuthService(UserManager<ApplicationUser> userManager,
			IOptions<JwtSettings> jwtSettings,
			SignInManager<ApplicationUser> signInManager)
		{
			_userManager = userManager;
			_jwtSettings = jwtSettings;
			_signInManager = signInManager;
		}

		public Task<AuthResponse> Login(AuthRequest authRequest)
		{
			throw new NotImplementedException();
		}

		public async Task<RegistrationResponse> Reqister(RegisterationRequest request)
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
	}
}
