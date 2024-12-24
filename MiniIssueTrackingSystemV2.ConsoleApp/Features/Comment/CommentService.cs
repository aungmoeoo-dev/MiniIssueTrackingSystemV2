using MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment;

public class CommentService
{
	private readonly RestClient _restClient;

	public CommentService()
	{
		_restClient = new RestClient();
	}

	public async Task<CommentResponseModel> CreateComment(CommentModel requestModel)
	{
		RestRequest issueRequest = new("https://localhost:7226/api/comment", Method.Post);
		issueRequest.AddJsonBody(requestModel);
		RestResponse issueResponse = await _restClient.ExecuteAsync(issueRequest);
		string issueContent = issueResponse.Content!;

		return JsonConvert.DeserializeObject<CommentResponseModel>(issueContent)!;
	}

	public async Task<CommentListResponseModel> GetComments()
	{
		RestRequest issueRequest = new("https://localhost:7226/api/comment");
		RestResponse issueResponse = await _restClient.ExecuteAsync(issueRequest);
		string issueContent = issueResponse.Content!;

		return JsonConvert.DeserializeObject<CommentListResponseModel>(issueContent)!;
	}
}
