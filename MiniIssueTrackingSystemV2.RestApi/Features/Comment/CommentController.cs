using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Comment;
using MiniIssueTrackingSystemV2.Domain.Features.Comment.Model;
using MiniIssueTrackingSystemV2.Domain.Features.Issue;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;

namespace MiniIssueTrackingSystemV2.RestApi.Features.Comment
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentController : ControllerBase
	{
		private readonly ICommentService _commentService;

		public CommentController()
		{
			_commentService = new CommentService();
		}

		[HttpPost]
		public async Task<IActionResult> CreateComment([FromBody] CommentModel requestModel)
		{
			CommentResponseModel responseModel = new();

			try
			{
				responseModel = await _commentService.CreateComment(requestModel);
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

		[HttpPatch("{id}")]
		public async Task<IActionResult> UpdateComment(string id, [FromBody] CommentModel requestModel)
		{
			CommentResponseModel responseModel = new();

			try
			{
				requestModel.Id = id;
				responseModel = await _commentService.UpdateComment(requestModel);
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
}


