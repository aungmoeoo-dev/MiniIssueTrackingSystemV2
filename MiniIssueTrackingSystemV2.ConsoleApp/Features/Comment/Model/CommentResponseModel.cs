namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;

public class CommentResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public CommentModel Data { get; set; }
}
