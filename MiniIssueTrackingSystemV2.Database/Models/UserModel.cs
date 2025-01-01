using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Database.Models;

[Table("TBL_User")]
public class UserModel
{
	[Key]
	public string? Id { get; set; }
	public string? Username { get; set; }
	public string? Email { get; set; }
}
