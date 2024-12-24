using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue
{
	public interface IIssueService
	{
		Task<IssueListResponseModel> GetIssues();
		Task<IssueResponseModel> AssignIssue(IssueModel requestModel);
		Task<IssueResponseModel> ChangeIssueStatus(IssueModel requestModel);
		Task<IssueCreateResponseModel> CreateIssue(IssueModel requestModel);
	}
}