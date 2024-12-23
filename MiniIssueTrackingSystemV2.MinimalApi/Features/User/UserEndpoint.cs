using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.User;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;

namespace MiniIssueTrackingSystemV2.MinimalApi.Features.User;

public static class UserEndpoint
{
	public static IEndpointRouteBuilder UseUserEndpoint(this IEndpointRouteBuilder app)
	{
		app.MapPost("/api/user", async ([FromBody] UserModel requestModel) =>
		{
			UserRegisterResponseModel responseModel = new();

			IUserService userService = new UserService();

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
		.WithOpenApi(); ;

		return app;

	}
}
