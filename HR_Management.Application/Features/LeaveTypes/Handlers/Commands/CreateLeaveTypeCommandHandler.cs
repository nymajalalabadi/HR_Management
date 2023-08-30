using AutoMapper;
using HR_Management.Application.DTOS.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management_Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using HR_Management_Domain.Common;
using HR_Management.Application.Responses;
using System.Linq;

namespace HR_Management.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler
        : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponses>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponses> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
			var response = new BaseCommandResponses();

			var validator = new CreateLeaveTypeDtoValidator();

            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto);

			if (validationResult.IsValid == false)
			{
				//throw new ValidationException(validationResult);
				response.Success = false;
				response.Message = "Creation Faild";
				response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
			}


			var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);

            leaveType = await _leaveTypeRepository.Add(leaveType);

			response.Success = true;
			response.Message = "Creation Successful";
			response.Id = leaveType.Id;

			return response;
        }
    }
}
