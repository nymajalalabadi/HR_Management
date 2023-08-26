using HR_Management.Application.Contracts.Persistence;
using HR_Management_Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.UnitTests.Mocks
{
	public static class MockLeaveTypeRepository
	{
		public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
		{
			var leaveTypes = new List<LeaveType>() 
			{ 
				new LeaveType 
				{ 
					Id = 1,
					DefaultDay = 10,
					Name = "TestVaciton",
				},
				new LeaveType
				{
					Id = 2,
					DefaultDay = 9,
					Name = "Test Sick",
				},
			};

			var mockRepository = new Mock<ILeaveTypeRepository>();

			mockRepository.Setup(l => l.GetAll()).ReturnsAsync(leaveTypes);

			mockRepository.Setup(l => l.Add(It.IsAny<LeaveType>())).ReturnsAsync( (LeaveType leavetype) => 
		    {
				leaveTypes.Add(leavetype);
				return leavetype;
			});



			return mockRepository;
		}
	}
}
