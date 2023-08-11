using HR_Management.Application.DTOS.LeaveRequest;
using HR_Management.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Commands
{
    public class CreateLeaveRequestsCommand : IRequest<BaseCommandResponses>
    {
        public CreateLeaveRequestsDto CreateLeaveRequestsDto { get; set; }
    }
}
