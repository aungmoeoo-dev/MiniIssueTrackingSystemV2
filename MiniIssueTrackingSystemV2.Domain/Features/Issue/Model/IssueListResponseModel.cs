using MiniIssueTrackingSystemV2.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

public class IssueListResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public List<IssueModel> Data { get; set; }
}
