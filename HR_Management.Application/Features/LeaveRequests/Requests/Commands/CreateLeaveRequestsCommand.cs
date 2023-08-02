using HR_Management.Application.DTOS.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestsCommand : IRequest<int>
    {
        public LeaveRequestDto LeaveRequestDto { get; set; }
    }
}
