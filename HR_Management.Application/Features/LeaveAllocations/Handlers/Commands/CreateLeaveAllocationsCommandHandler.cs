using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationsCommandHandler
        : IRequestHandler<CreateLeaveAllocationsCommand, int>
    {
        public CreateLeaveAllocationsCommandHandler()
        {
                
        }

        public Task<int> Handle(CreateLeaveAllocationsCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
