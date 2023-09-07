using HR.Management.Identity.Configurations;
using HR.Management.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Identity
{
	public class LeaveTypeManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
	{
		public LeaveTypeManagementIdentityDbContext(DbContextOptions<LeaveTypeManagementIdentityDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new RoleConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
		}
	}
}

