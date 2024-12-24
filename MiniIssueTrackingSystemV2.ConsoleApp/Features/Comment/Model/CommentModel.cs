using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;

public class CommentModel
{
	public string? Id { get; set; }
	public string? IssueId { get; set; }
	public string? Text { get; set; }
	public string? CreatedBy { get; set; }
}
