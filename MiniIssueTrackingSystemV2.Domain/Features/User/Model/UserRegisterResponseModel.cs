using MiniIssueTrackingSystemV2.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.User.Model;

public class UserRegisterResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public UserModel Data { get; set; }
}
