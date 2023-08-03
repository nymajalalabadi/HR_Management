using HR_Management.Application.DTOS.LeaveType;
using MediatR;
using System.Collections.Generic;

namespace HR_Management.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {

    }
}
