namespace MiniIssueTrackingSystemV2.ConsoleApp.Dtos;

public class IssueDto
{
	public string? Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public UserDto CreatedBy { get; set; }
	public IssueStatus? Status { get; set; }
	public UserDto AssignedTo { get; set; }
	public List<CommentDto> Comments { get; set; }

	public override string ToString()
	{
		var assignedTo = AssignedTo == null ? "None" : AssignedTo.Username;
		return $"ID: {Id}, Title: {Title}, Description: {Description}, Status: {Status}, Created By: {CreatedBy.Username}, Assigned To: {assignedTo}, Comments: {Comments.Count}";
	}

}
