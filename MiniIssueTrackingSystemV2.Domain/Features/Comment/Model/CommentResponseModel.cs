using MiniIssueTrackingSystemV2.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.Comment.Model;

public class CommentResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public TBLComment Data { get; set; }
}
