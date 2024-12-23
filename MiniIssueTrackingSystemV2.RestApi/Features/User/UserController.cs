using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.User;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;

namespace MiniIssueTrackingSystemV2.RestApi.Features.User;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController()
	{
		_userService = new UserService();
	}

	[HttpPost]
	public async Task<IActionResult> RegisterUser([FromBody] UserModel requestModel)
	{
		UserRegisterResponseModel responseModel = new();

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
}
