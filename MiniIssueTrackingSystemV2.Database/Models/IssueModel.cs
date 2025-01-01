using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniIssueTrackingSystemV2.Database.Models;

[Table("TBL_Issue")]
public class IssueModel
{
	[Key]
	public string? Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public string? CreatedBy { get; set; }
	public IssueStatus? Status { get; set; }
	public string? AssignedTo { get; set; }

}
