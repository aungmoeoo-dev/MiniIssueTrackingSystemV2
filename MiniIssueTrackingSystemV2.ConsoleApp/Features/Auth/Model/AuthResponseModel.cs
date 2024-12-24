using MiniIssueTrackingSystemV2.ConsoleApp.Features.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Auth.Model;

public class AuthResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public UserModel Data { get; set; }
}
