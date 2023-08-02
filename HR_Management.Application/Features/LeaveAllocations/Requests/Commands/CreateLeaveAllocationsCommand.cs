using HR_Management.Application.DTOS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.Features.LeaveAllocations.Requests.Commands
{
    public class CreateLeaveAllocationsCommand : IRequest<int>
    {
        public LeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
