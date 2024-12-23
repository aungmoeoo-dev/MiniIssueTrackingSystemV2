using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;

namespace MiniIssueTrackingSystemV2.Domain.Features.User
{
	public interface IUserService
	{
		Task<UserRegisterResponseModel> RegisterUser(UserModel requestModel);
	}
}