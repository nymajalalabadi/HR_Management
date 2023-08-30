using HR_Management.Application.DTOS.LeaveType;
using HR_Management.Application.Responses;
using HR_Management_Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponses>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
    }
}
