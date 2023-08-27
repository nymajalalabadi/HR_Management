using AutoMapper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOS.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Queries;
using HR_Management.Application.Features.LeaveTypes.Requests.Queries;
using HR_Management.Application.Profiles;
using HR_Management.Application.UnitTests.Mocks;
using HR_Management_Domain;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.UnitTests.LeaveTypes.Queries
{
	public class GetLeaveTypeListRequestHandlerTest
	{
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        public GetLeaveTypeListRequestHandlerTest()
        {
            _mockRepository = MockLeaveTypeRepository.GetLeaveTypeRepository();

            var mapperConfing = new MapperConfiguration(m => 
            {
                m.AddProfile<MappingProfile>();
            });

             _mapper = mapperConfing.CreateMapper();
        }

        [Fact]
        public async Task GetLeaveTypeListTest()
        {
            var handler = new GetLeaveTypeListRequestHandler(_mockRepository.Object , _mapper);

            var reuslt = await handler.Handle(new GetLeaveTypeListRequest(), CancellationToken.None);

            reuslt.ShouldBeOfType<List<LeaveTypeDto>>();
            reuslt.Count.ShouldBe(2);

		}
    }
}
