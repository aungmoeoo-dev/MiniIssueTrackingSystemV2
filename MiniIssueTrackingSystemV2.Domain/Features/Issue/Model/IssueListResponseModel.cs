using MiniIssueTrackingSystemV2.Database.Models;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

public class IssueListResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public List<TBLIssue> Data { get; set; }
}
