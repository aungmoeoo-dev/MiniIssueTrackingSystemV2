using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniIssueTrackingSystemV2.Database.Models;

namespace MiniIssueTrackingSystemV2.Database;

public class AppDbContext : DbContext
{
	private readonly SqlConnectionStringBuilder _connectionStringBuilder = new()
	{
		DataSource = ".",
		InitialCatalog = "MiniIssueTrackingSystemV2DB",
		UserID = "sa",
		Password = "Aa145156167!",
		TrustServerCertificate = true
	};

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if(!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(_connectionStringBuilder.ConnectionString);
		}
	}

	public DbSet<UserModel> Users { get; set; }
	public DbSet<IssueModel> Issues { get; set; }
	public DbSet<CommentModel> Comments { get; set; }
}
