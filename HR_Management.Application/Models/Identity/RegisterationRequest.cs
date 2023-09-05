using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HR_Management.Application.Models.Identity
{
	public class RegisterationRequest
	{
		[Required]
		public string FirstName { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[MinLength(6)]
		public string UserName { get; set; }

		[Required]
		[MinLength(6)]
		public string Password { get; set; }
	}
}
