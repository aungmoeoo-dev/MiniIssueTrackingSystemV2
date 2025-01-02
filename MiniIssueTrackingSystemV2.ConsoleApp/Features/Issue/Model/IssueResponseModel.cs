using MiniIssueTrackingSystemV2.ConsoleApp.Dtos;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Issue.Model;

public class IssueResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public IssueDto Data { get; set; }
}
