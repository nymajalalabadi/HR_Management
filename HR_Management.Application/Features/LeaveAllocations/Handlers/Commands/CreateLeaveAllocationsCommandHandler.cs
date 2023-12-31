﻿using AutoMapper;
using HR_Management.Application.DTOS.LeaveAllocation.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveAllocations.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management_Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationsCommandHandler
        : IRequestHandler<CreateLeaveAllocationsCommand, int>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveAllocationsCommandHandler(ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateLeaveAllocationsCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            

            var leaveAllocation = _mapper.Map<LeaveAllocation>(request.CreateLeaveAllocationDto);

            leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);

            return leaveAllocation.Id;
        }
    }
}
