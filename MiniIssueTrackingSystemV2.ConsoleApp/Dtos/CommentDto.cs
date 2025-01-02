namespace MiniIssueTrackingSystemV2.ConsoleApp.Dtos;

public class CommentDto
{
	public string? Id { get; set; }
	public string? IssueId { get; set; }
	public string? Text { get; set; }
	public UserDto CreatedBy { get; set; }

	public override string ToString()
	{
		return $"{CreatedBy}: {Text}";
	}
}
