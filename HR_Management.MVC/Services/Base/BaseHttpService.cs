using HR_Management.MVC.Contracts;
using System.Net.Http.Headers;

namespace HR_Management.MVC.Services.Base
{
	public class BaseHttpService
	{
		protected readonly ILocalStrogeService _localStroge;
		protected readonly IClient _client;

		public BaseHttpService(IClient client, ILocalStrogeService localStroge)
		{
			_localStroge = localStroge;
			_client = client;
		}

		protected Response<Guid> ConvertApiExceptions<Guid>(ApiException exception)
		{
			if (exception.StatusCode == 400)
			{
				return new Response<Guid>
				{
					Message = "Validation Errors Have Occured",
					ValidationErrors = exception.Response,
					Success = false
				};
			}

			if (exception.StatusCode == 404)
			{
				return new Response<Guid>
				{
					Message = "Not Found",
					Success = false
				};
			}

			else
			{
				return new Response<Guid>
				{
					Message = "SomeThing Went Wrong , Try Again..",
					Success = false
				};
			}
		}


		protected void AddBearerToken()
		{
			if (_localStroge.Exists("token"))
			{
				_client.HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _localStroge.GetStrogeValue<string>("token")); 
			}
		}
	}
}
