using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;

public class CommentListResponseModel
{
	public bool IsSuccess { get; set; }
	public string Message { get; set; }
	public List<CommentModel> Data { get; set; }
}
