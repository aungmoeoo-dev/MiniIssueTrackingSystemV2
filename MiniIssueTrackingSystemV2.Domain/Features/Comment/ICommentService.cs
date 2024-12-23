using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Comment.Model;

namespace MiniIssueTrackingSystemV2.Domain.Features.Comment
{
	public interface ICommentService
	{
		Task<CommentResponseModel> CreateComment(CommentModel requestModel);
		Task<CommentResponseModel> UpdateComment(CommentModel requestModel);
	}
}