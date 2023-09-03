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

		public LeaveTypeService(IMapper mapper, IClient htppClient, ILocalStrogeService localStrogeService) : base(htppClient, localStrogeService)
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

		public async Task<Response<int>> DeleteLeaveType(int id)
		{
			try
			{
				await _client.LeaveTypesDELETEAsync(id);

				return new Response<int> { Success = true };
			}
			catch (ApiException ex)
			{

				return ConvertApiExceptions<int>(ex);
			}
		}

		public async Task<LeaveTypeVM> GetLeaveTypeDetails(int id)
		{
			var leavetype = await _client.LeaveTypesGETAsync(id);

			return _mapper.Map<LeaveTypeVM>(leavetype);

		}

		public async Task<List<LeaveTypeVM>> GetLeaveTypes()
		{
			var leaveTypes = await _client.LeaveTypesAllAsync();
			return _mapper.Map<List<LeaveTypeVM>>(leaveTypes);
		}

		public async Task<Response<int>> UpdateLeaveType(LeaveTypeVM leaveType, int id)
		{
			try
			{
				LeaveTypeDto leaveTypeDto = _mapper.Map<LeaveTypeDto>(leaveType);

				await _client.LeaveTypesPUTAsync(id, leaveTypeDto);

				return new Response<int>
				{
					Success = true
				};
			}
			catch (ApiException ex)
			{
				return ConvertApiExceptions<int>(ex);
			}
		}
	}
}
