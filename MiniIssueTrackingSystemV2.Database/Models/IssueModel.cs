using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Database.Models;

public class IssueModel
{
	public string Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public string CreatedBy { get; set; }
	public IssueStatus Status { get; set; }
	public string AssignedTo { get; set; }

}
