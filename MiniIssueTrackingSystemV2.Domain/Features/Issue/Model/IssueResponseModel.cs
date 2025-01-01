using MiniIssueTrackingSystemV2.Domain.Dtos;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

public class IssueResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public IssueDto Data { get; set; }
}
