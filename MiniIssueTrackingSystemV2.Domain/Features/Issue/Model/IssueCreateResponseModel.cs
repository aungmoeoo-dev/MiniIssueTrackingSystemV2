using MiniIssueTrackingSystemV2.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

public class IssueCreateResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public IssueModel Data { get; set; }
}
