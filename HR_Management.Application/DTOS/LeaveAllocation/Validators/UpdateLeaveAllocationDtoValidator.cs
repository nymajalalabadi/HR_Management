using FluentValidation;
using HR_Management.Application.Persistence.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOS.LeaveAllocation.Validators
{
    public class UpdateLeaveAllocationDtoValidator : AbstractValidator<UpdateLeaveAllocationDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public UpdateLeaveAllocationDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            Include(new ILeaveAllocationDtoValidator(_leaveTypeRepository));

            RuleFor(p => p.Id)
               .NotNull().WithMessage("{PropertyName} is required");
        }
    }
}
