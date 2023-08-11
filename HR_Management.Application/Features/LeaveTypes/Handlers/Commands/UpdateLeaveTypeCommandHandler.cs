using AutoMapper;
using HR_Management.Application.DTOS.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Persistence.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper; 
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();

            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            

            var leavetype = await _leaveTypeRepository.Get(request.LeaveTypeDto.Id);

            _mapper.Map(request.LeaveTypeDto, leavetype);

            await _leaveTypeRepository.Update(leavetype);

            return Unit.Value;
        }
    }
}
