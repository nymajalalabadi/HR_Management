using HR_Management.MVC.Mapping;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Contracts
{
	public interface ILeaveTypeService
	{
		Task<List<LeaveTypeVM>> GetLeaveTypes();

		Task<LeaveTypeVM> GetLeaveTypeDetails(int id);

		Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType);

		Task<Response<int>> UpdateLeaveType(LeaveTypeVM leaveType, int id);
		Task<Response<int>> DeleteLeaveType(int id);
	}
}
