using MiniIssueTrackingSystemV2.ConsoleApp.Features.Issue.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Issue;

public class IssueService
{
	private readonly RestClient _restClient;

	public IssueService()
	{
		_restClient = new RestClient();
	}

	public async Task<IssueListResponseModel> GetIssues()
	{
		RestRequest issueRequest = new("https://localhost:7226/api/issue");
		RestResponse issueResponse = await _restClient.ExecuteAsync(issueRequest);
		string issueContent = issueResponse.Content!;

		return JsonConvert.DeserializeObject<IssueListResponseModel>(issueContent)!;
	}

	public async Task<IssueResponseModel> CreateIssue(IssueModel requestModel)
	{
		RestRequest issueRequest = new("https://localhost:7226/api/issue", Method.Post);
		issueRequest.AddJsonBody(requestModel);
		RestResponse issueResponse = await _restClient.ExecuteAsync(issueRequest);
		string issueContent = issueResponse.Content!;

		return  JsonConvert.DeserializeObject<IssueResponseModel>(issueContent)!;
	}

	public async Task<IssueResponseModel> ChangeIssueStatus(IssueModel requestModel)
	{
		RestRequest issueRequest = new($"https://localhost:7226/api/issue/status/{requestModel.Id}", Method.Patch);
		issueRequest.AddJsonBody(requestModel);
		RestResponse issueResponse = await _restClient.ExecuteAsync(issueRequest);
		string issueContent = issueResponse.Content!;

		return JsonConvert.DeserializeObject<IssueResponseModel>(issueContent)!;
	}

	public async Task<IssueResponseModel> AssignIssue(IssueModel requestModel)
	{
		RestRequest issueRequest = new($"https://localhost:7226/api/issue/assign/{requestModel.Id}", Method.Patch);
		issueRequest.AddJsonBody(requestModel);
		RestResponse issueResponse = await _restClient.ExecuteAsync(issueRequest);
		string issueContent = issueResponse.Content!;

		return JsonConvert.DeserializeObject<IssueResponseModel>(issueContent)!;
	}
}
