using MiniIssueTrackingSystemV2.Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Dtos;

public class IssueDto
{
	public string? Id { get; set; }
	public string? Title { get; set; }
	public string? Description { get; set; }
	public UserDto CreatedBy { get; set; }
	public IssueStatus? Status { get; set; }
	public UserDto AssignedTo { get; set; }
	public List<CommentDto> Comments { get; set; }

}
