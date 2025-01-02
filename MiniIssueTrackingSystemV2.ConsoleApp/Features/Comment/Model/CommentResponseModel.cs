using MiniIssueTrackingSystemV2.ConsoleApp.Dtos;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;

public class CommentResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public CommentDto Data { get; set; }
}
