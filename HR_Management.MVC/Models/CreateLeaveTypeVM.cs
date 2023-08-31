using System.ComponentModel.DataAnnotations;

namespace HR_Management.MVC.Models
{
	public class CreateLeaveTypeVM
	{
		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Default Number Of Day")]
		public int DefaultDay { get; set; }
	}
}
