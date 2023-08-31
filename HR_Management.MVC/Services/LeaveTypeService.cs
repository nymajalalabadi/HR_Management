using AutoMapper;
using HR_Management.MVC.Contracts;
using HR_Management.MVC.Mapping;
using HR_Management.MVC.Services.Base;

namespace HR_Management.MVC.Services
{
	public class LeaveTypeService : BaseHttpService, ILeaveTypeService
	{
		private readonly IClient _htppClient;
		private readonly ILocalStrogeService _localStrogeService;
		private readonly IMapper _mapper;

		public LeaveTypeService(IMapper mapper , IClient htppClient, ILocalStrogeService localStrogeService) : base(htppClient, localStrogeService)
        {
			_mapper = mapper;
            _htppClient = htppClient;
			_localStrogeService = localStrogeService;
        }

        public async Task<Response<int>> CreateLeaveType(LeaveTypeVM leaveType)
		{
			try
			{
				var response = new Response<int>();

				CreateLeaveTypeDto createLeaveTypeDto =
					_mapper.Map<CreateLeaveTypeDto>(leaveType);

				//TODO Auth

				var apiResponse = await _client.LeaveTypesPOSTAsync(createLeaveTypeDto);

				if (apiResponse.Success)
				{
					response.Data = apiResponse.Id;
					response.Success = true;
				}
				else
				{
					foreach (var err in apiResponse.Errors)
					{
						response.ValidationErrors += err + Environment.NewLine;
					}
				}

				return response;
			}
			catch (ApiException ex)
			{
				return ConvertApiExceptions<int>(ex);
			}
		}

		public Task DeleteLeaveType(LeaveTypeVM leaveType)
		{
			throw new NotImplementedException();
		}

		public Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<LeaveTypeVM>> GetLeaveTypes()
		{
			throw new NotImplementedException();
		}

		public Task UpdateLeaveType(LeaveTypeVM leaveType)
		{
			throw new NotImplementedException();
		}
	}
}
