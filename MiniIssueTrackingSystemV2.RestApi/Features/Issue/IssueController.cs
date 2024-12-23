using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Issue;
using MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;
using MiniIssueTrackingSystemV2.Domain.Features.User;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;

namespace MiniIssueTrackingSystemV2.RestApi.Features.Issue;

[Route("api/[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
	private readonly IIssueService _issueService;

	public IssueController()
	{
		_issueService = new IssueService();
	}

	[HttpPost]
	public async Task<IActionResult> CreateIssue([FromBody] IssueModel requestModel)
	{
		IssueCreateResponseModel responseModel = new();

		try
		{
			responseModel = await _issueService.CreateIssue(requestModel);
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

	[HttpPatch("status/{id}")]
	public async Task<IActionResult> ChangeStatus(string id, [FromBody] IssueModel requestModel)
	{
		IssueResponseModel responseModel = new();

		try
		{
			requestModel.Id = id;
			responseModel = await _issueService.ChangeStatus(requestModel);
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

	[HttpPatch("assign/{id}")]
	public async Task<IActionResult> AssignIssue(string id, [FromBody] IssueModel requestModel)
	{
		IssueResponseModel responseModel = new();

		try
		{
			requestModel.Id = id;
			responseModel = await _issueService.AssignIssue(requestModel);
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
