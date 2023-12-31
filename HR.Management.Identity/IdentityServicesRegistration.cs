﻿using HR.Management.Identity.Models;
using HR.Management.Identity.Services;
using HR_Management.Application.Contracts.Identity;
using HR_Management.Application.Models.Identity;
using HR_Management.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Management.Identity
{
	public static class IdentityServicesRegistration
	{
		public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<JwtSettings>(configuration.GetSection("JwtSetting"));

			services.AddDbContext<LeaveTypeManagementIdentityDbContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("LeaveManagementIdentityConnectionString"),
					b => b.MigrationsAssembly(typeof(LeaveTypeManagementIdentityDbContext).Assembly.FullName)
					);
			});

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<LeaveTypeManagementIdentityDbContext>().AddDefaultTokenProviders();

			services.AddTransient<IAuthService, AuthService>();

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			  .AddJwtBearer(o =>
			  {
				  o.TokenValidationParameters = new TokenValidationParameters
				  {
					  ValidateIssuerSigningKey = true,
					  ValidateIssuer = true,
					  ValidateAudience = true,
					  ValidateLifetime = true,
					  ClockSkew = TimeSpan.Zero,
					  ValidIssuer = configuration["JwtSettings:Issuer"],
					  ValidAudience = configuration["JwtSettings:Audience"],
					  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
				  };
			  });

			return services;
		}
	}
}
