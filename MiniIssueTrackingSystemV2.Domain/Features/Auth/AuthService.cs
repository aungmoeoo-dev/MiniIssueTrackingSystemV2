using Microsoft.EntityFrameworkCore;
using MiniIssueTrackingSystemV2.Database;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.Auth;

public class AuthService : IAuthService
{
	private readonly AppDbContext _db;

	public AuthService()
	{
		_db = new AppDbContext();
	}

	public async Task<AuthResponseModel> RegisterUser(UserModel requestModel)
	{
		AuthResponseModel responseModel = new();

		requestModel.Id = Guid.NewGuid().ToString();
		_db.Users.Add(requestModel);
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "User registeration successful." : "User registeration failed.";
		responseModel.Data = result > 0 ? requestModel : null;
		return responseModel;
	}

	public async Task<AuthResponseModel> LoginUser(UserModel requestModel)
	{
		AuthResponseModel responseModel = new();

		var user = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Username == requestModel.Username);

		responseModel.IsSuccess = user is not null;
		responseModel.Message = user is not null ? "User login successful." : "User login failed.";
		responseModel.Data = user!;
		return responseModel;
	}
}
