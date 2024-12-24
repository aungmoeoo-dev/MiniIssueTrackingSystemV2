using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Issue;
using MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

namespace MiniIssueTrackingSystemV2.RestApi.Features.Issue;

[Route("api/[controller]")]
[ApiController]
public class IssueController : ControllerBase
{
	private readonly IssueService _issueService;

	public IssueController()
	{
		_issueService = new IssueService();
	}

	[HttpGet]
	public async Task<IActionResult> GetIssues()
	{
		IssueListResponseModel responseModel = new();

		try
		{
			responseModel = await _issueService.GetIssues();
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

	[HttpPost]
	public async Task<IActionResult> CreateIssue([FromBody] TBLIssue requestModel)
	{
		IssueResponseModel responseModel = new();

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
	public async Task<IActionResult> ChangeIssueStatus(string id, [FromBody] TBLIssue requestModel)
	{
		IssueResponseModel responseModel = new();

		try
		{
			requestModel.Id = id;
			responseModel = await _issueService.ChangeIssueStatus(requestModel);
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
	public async Task<IActionResult> AssignIssue(string id, [FromBody] TBLIssue requestModel)
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
