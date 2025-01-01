using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Auth;
using MiniIssueTrackingSystemV2.Domain.Features.Auth.Model;

namespace MiniIssueTrackingSystemV2.RestApi.Features.User;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly AuthService _userService;

	public AuthController()
	{
		_userService = new AuthService();
	}

	[HttpPost("Register")]
	public async Task<IActionResult> RegisterUser([FromBody] UserModel requestModel)
	{
		AuthResponseModel responseModel = new();

		try
		{
			responseModel = await _userService.RegisterUser(requestModel);
			if (!responseModel.IsSuccess) return BadRequest(responseModel);

			return Ok(responseModel);
		}
		catch (Exception ex)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = ex.ToString();
			return StatusCode(500, responseModel);
		}
	}

	[HttpPost("Login")]
	public async Task<IActionResult> LoginUser([FromBody] UserModel requestModel)
	{
		AuthResponseModel responseModel = new();

		try
		{
			responseModel = await _userService.LoginUser(requestModel);
			if (!responseModel.IsSuccess) return BadRequest(responseModel);

			return Ok(responseModel);
		}
		catch (Exception ex)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = ex.ToString();
			return StatusCode(500, responseModel);
		}
	}
}
