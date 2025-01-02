using MiniIssueTrackingSystemV2.ConsoleApp.Dtos;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Auth.Model;

public class AuthResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public UserDto Data { get; set; }
}
