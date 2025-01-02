using MiniIssueTrackingSystemV2.ConsoleApp.Dtos;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.User.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Issue.Model;

public class IssueModel
{
	public string? Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public string? CreatedBy { get; set; }
	public IssueStatus? Status { get; set; }
	public string? AssignedTo { get; set; }
}

