using AutoMapper;
using HR_Management.Application.DTOS.LeaveRequest.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Persistence.Contracts;
using HR_Management.Application.Responses;
using HR_Management_Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestsCommandHandler
        : IRequestHandler<CreateLeaveRequestsCommand, BaseCommandResponses>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;
        public CreateLeaveRequestsCommandHandler(ILeaveRequestRepository leaveRequestRepository, ILeaveTypeRepository leaveTypeRepository,
            IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponses> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponses();

            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestsDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestsDto);
            leaveRequest = await _leaveRequestRepository.Add(leaveRequest);


            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveRequest.Id;

            return response;
        }
    }
}
