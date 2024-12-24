using MiniIssueTrackingSystemV2.Database.Models;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

public class IssueResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public TBLIssue Data { get; set; }
}
