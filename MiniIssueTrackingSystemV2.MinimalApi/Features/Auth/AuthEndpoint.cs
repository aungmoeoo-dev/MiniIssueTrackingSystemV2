using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Auth;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;

namespace MiniIssueTrackingSystemV2.MinimalApi.Features.User;

public static class AuthEndpoint
{
	public static IEndpointRouteBuilder UseAuthEndpoint(this IEndpointRouteBuilder app)
	{
		app.MapPost("/api/auth/register", async ([FromBody] UserModel requestModel) =>
		{
			AuthResponseModel responseModel = new();

			IAuthService userService = new AuthService();

			try
			{
				responseModel = await userService.RegisterUser(requestModel);
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
		.WithName("Register user")
		.WithOpenApi();

		app.MapPost("/api/auth/login", async ([FromBody] UserModel requestModel) =>
		{
			AuthResponseModel responseModel = new();

			IAuthService userService = new AuthService();

			try
			{
				responseModel = await userService.LoginUser(requestModel);
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
		.WithName("Login user")
		.WithOpenApi();

		return app;

	}
}
