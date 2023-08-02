using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestsCommandHandler
        : IRequestHandler<CreateLeaveRequestsCommand, int>
    {
        public Task<int> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
