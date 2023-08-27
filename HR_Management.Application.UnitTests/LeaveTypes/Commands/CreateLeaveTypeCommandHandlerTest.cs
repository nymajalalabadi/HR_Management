using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOS.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.UnitTests.LeaveTypes.Commands
{
	public class CreateLeaveTypeCommandHandlerTest
	{
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
		CreateLeaveTypeDto _leaveTypeDto;

		public CreateLeaveTypeCommandHandlerTest()
        {
            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

			var mapperConfing = new MapperConfiguration(m =>
			{
				m.AddProfile<MappingProfile>();
			});

			_mapper = mapperConfing.CreateMapper();

			_leaveTypeDto = new CreateLeaveTypeDto()
			{
				Name = "Name",
				DefaultDay = 15
			};
		}

		[Fact]
		public async Task CreateLeaveType()
		{
			var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object, _mapper);

			var result = handler.Handle(new CreateLeaveTypeCommand() { CreateLeaveTypeDto = _leaveTypeDto }, CancellationToken.None);

			result.ShouldBeOfType<int>();

			var leaveTypes = await _mockRepository.Object.GetAll();

			leaveTypes.Count.ShouldBe(3);
		}

	}
}
