using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Database.Models;

[Table("TBL_Comment")]
public class CommentModel
{
	[Key]
	public string? Id { get; set; }
	public string? Text { get; set; }
	public string? CreatedBy { get; set; }
}
