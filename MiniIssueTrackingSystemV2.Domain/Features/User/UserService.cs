using MiniIssueTrackingSystemV2.Database;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.User;

public class UserService : IUserService
{
	private readonly AppDbContext _db;

	public UserService()
	{
		_db = new AppDbContext();
	}

	public async Task<UserRegisterResponseModel> RegisterUser(UserModel requestModel)
	{
		UserRegisterResponseModel responseModel = new();

		requestModel.Id = Guid.NewGuid().ToString();
		_db.Users.Add(requestModel);
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "User registeration successful." : "User registeration failed.";
		responseModel.Data = result > 0 ? requestModel : null;
		return responseModel;
	}
}
