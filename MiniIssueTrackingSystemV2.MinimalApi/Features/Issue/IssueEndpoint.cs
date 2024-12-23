using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Issue;
using MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

namespace MiniIssueTrackingSystemV2.MinimalApi.Features.Issue;

public static class UserEndpoint
{
	public static IEndpointRouteBuilder UseIssueEndpoint(this IEndpointRouteBuilder app)
	{
		app.MapPost("api/issue", async ([FromBody] IssueModel requestModel) =>
		{
			IssueCreateResponseModel responseModel = new();

			IIssueService issueService = new IssueService();

			try
			{
				responseModel = await issueService.CreateIssue(requestModel);
				if (!responseModel.IsSuccess) Results.BadRequest(responseModel);

				Results.Ok(responseModel);
			}
			catch (Exception ex)
			{
				responseModel.IsSuccess = false;
				responseModel.Message = ex.ToString();
				Results.Json(responseModel, statusCode: 500);
			}
		})
		.WithName("Create issue")
		.WithOpenApi();

		app.MapPatch("api/issue/status/{id}", async (string id, [FromBody] IssueModel requestModel) =>
		{
			IssueResponseModel responseModel = new();

			IIssueService issueService = new IssueService();

			try
			{
				requestModel.Id = id;
				responseModel = await issueService.ChangeStatus(requestModel);
				if (!responseModel.IsSuccess) Results.BadRequest(responseModel);

				Results.Ok(responseModel);
			}
			catch (Exception ex)
			{
				responseModel.IsSuccess = false;
				responseModel.Message = ex.ToString();
				Results.Json(responseModel, statusCode: 500);
			}
		})
		.WithName("Update issue status")
		.WithOpenApi();

		app.MapPatch("api/issue/assign/{id}", async (string id, [FromBody] IssueModel requestModel) =>
		{
			IssueResponseModel responseModel = new();

			IIssueService issueService = new IssueService();

			try
			{
				requestModel.Id = id;
				responseModel = await issueService.AssignIssue(requestModel);
				if (!responseModel.IsSuccess) Results.BadRequest(responseModel);

				Results.Ok(responseModel);
			}
			catch (Exception ex)
			{
				responseModel.IsSuccess = false;
				responseModel.Message = ex.ToString();
				Results.Json(responseModel, statusCode: 500);
			}
		})
		.WithName("Update issue assign")
		.WithOpenApi();

		return app;

	}

}