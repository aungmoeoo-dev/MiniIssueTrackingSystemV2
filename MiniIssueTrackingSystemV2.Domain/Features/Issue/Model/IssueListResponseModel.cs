using MiniIssueTrackingSystemV2.Domain.Dtos;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

public class IssueListResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public List<IssueDto> Data { get; set; }
}
