using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Comment;
using MiniIssueTrackingSystemV2.Domain.Features.Comment.Model;

namespace MiniIssueTrackingSystemV2.MinimalApi.Features.Comment;

public static class CommentEndpoint
{
	public static IEndpointRouteBuilder UseCommentEndpoint(this IEndpointRouteBuilder app)
	{
		app.MapGet("api/comment", async () =>
		{
			CommentListResponseModel responseModel = new();

			ICommentService commentService = new CommentService();

			try
			{
				responseModel = await commentService.GetComments();
				if (!responseModel.IsSuccess) return Results.BadRequest(responseModel);

				return Results.Ok(responseModel);
			}
			catch (Exception ex)
			{
				responseModel.IsSuccess = false;
				responseModel.Message = ex.ToString();
				return Results.Json(responseModel, statusCode: 500);
			}
		})
		.WithName("Get comments")
		.WithOpenApi();

		app.MapPost("api/comment", async ([FromBody] CommentModel requestModel) =>
		{
			 CommentResponseModel responseModel = new();

			ICommentService commentService = new CommentService();

			try
			{
				responseModel = await commentService.CreateComment(requestModel);
				if (!responseModel.IsSuccess) return Results.BadRequest(responseModel);

				return Results.Ok(responseModel);
			}
			catch (Exception ex)
			{
				responseModel.IsSuccess = false;
				responseModel.Message = ex.ToString();
				return Results.Json(responseModel, statusCode: 500);
			}
		})
		.WithName("Create comment")
		.WithOpenApi();

		app.MapPatch("api/comment/{id}", async (string id, [FromBody] CommentModel requestModel) =>
		{
			CommentResponseModel responseModel = new();

			ICommentService commentService = new CommentService();

			try
			{
				requestModel.Id = id;
				responseModel = await commentService.UpdateComment(requestModel);
				if (!responseModel.IsSuccess) return Results.BadRequest(responseModel);

				return Results.Ok(responseModel);
			}
			catch (Exception ex)
			{
				responseModel.IsSuccess = false;
				responseModel.Message = ex.ToString();
				return Results.Json(responseModel, statusCode: 500);
			}
		})
		.WithName("Update comment")
		.WithOpenApi();

		return app;

	}
}
