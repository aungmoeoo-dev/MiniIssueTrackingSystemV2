using MiniIssueTrackingSystemV2.ConsoleApp.Features.Auth.Model;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.User.Model;
using Newtonsoft.Json;
using RestSharp;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Auth;

public class AuthService
{
	private readonly RestClient _restClient;

	public AuthService()
	{
		_restClient = new RestClient();
	}

	public async Task<AuthResponseModel> RegisterUser(UserModel requestModel)
	{
		RestRequest request = new("https://localhost:7226/api/auth/register", Method.Post);
		request.AddJsonBody(requestModel);
		RestResponse response = await _restClient.ExecuteAsync(request);

		string content = response.Content!;
		return JsonConvert.DeserializeObject<AuthResponseModel>(content)!;
	}

	public async Task<AuthResponseModel> LoginUser(UserModel requestModel)
	{
		RestRequest request = new("https://localhost:7226/api/auth/login", Method.Post);
		request.AddJsonBody(requestModel);
		RestResponse response = await _restClient.ExecuteAsync(request);

		string content = response.Content!;
		return JsonConvert.DeserializeObject<AuthResponseModel>(content)!;
	}
}
