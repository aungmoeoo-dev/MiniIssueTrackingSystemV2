using MiniIssueTrackingSystemV2.ConsoleApp.Dtos;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;

public class CommentListResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public List<CommentDto> Data { get; set; }
}
