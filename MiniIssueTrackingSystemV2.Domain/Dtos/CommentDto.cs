using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Dtos;

public class CommentDto
{
	public string? Id { get; set; }
	public string? IssueId { get; set; }
	public string? Text { get; set; }
	public UserDto CreatedBy { get; set; }
}
