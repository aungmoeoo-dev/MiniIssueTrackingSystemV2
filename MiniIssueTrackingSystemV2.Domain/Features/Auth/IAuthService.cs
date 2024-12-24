using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;

namespace MiniIssueTrackingSystemV2.Domain.Features.Auth
{
	public interface IAuthService
	{
		Task<AuthResponseModel> RegisterUser(UserModel requestModel);
		Task<AuthResponseModel> LoginUser(UserModel requestModel);
	}
}