using MiniIssueTrackingSystemV2.ConsoleApp.Dtos;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Issue.Model;

public class IssueListResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public List<IssueDto> Data { get; set; }
}
