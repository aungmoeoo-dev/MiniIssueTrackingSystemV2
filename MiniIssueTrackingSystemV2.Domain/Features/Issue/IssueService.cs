using Microsoft.EntityFrameworkCore;
using MiniIssueTrackingSystemV2.Database;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue;

public class IssueService
{
	private readonly AppDbContext _db;

	public IssueService()
	{
		_db = new AppDbContext();
	}

	public async Task<IssueResponseModel> CreateIssue(TBLIssue requestModel)
	{
		IssueResponseModel responseModel = new();

		requestModel.Id = Guid.NewGuid().ToString();
		requestModel.Status = IssueStatus.Open;
		_db.Issues.Add(requestModel);
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "Issue creation successful." : "User creation failed.";

		TBLUser createdByUser = await _db.Users.FirstOrDefaultAsync(x => x.Id == requestModel.CreatedBy);
		if (createdByUser is null)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "User does not exist.";
			return responseModel;
		}

		TBLIssue issueModel = new()
		{
			Id = requestModel.Id,
			Title = requestModel.Title!,
			Description = requestModel.Description!,
			CreatedBy = createdByUser.Id,
			Status = IssueStatus.Open,
		};

		responseModel.Data = result > 0 ? issueModel : null;
		return responseModel;
	}

	public async Task<IssueResponseModel> ChangeIssueStatus(TBLIssue requestModel)
	{
		IssueResponseModel responseModel = new();

		var issue = await _db.Issues.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.Id);
		if (issue is null)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "No data found.";
			return responseModel;
		}

		var issueOwner = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.CreatedBy);
		if (issueOwner is null)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "User does not exist.";
			return responseModel;
		}

		if (issueOwner.Id != requestModel.CreatedBy)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "Unauthorized";
			return responseModel;
		}

		issue.Status = requestModel.Status;
		_db.Entry(issue).State = EntityState.Modified;
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "Status updating successful" : "Status updating failed.";
		return responseModel;
	}

	public async Task<IssueResponseModel> AssignIssue(TBLIssue requestModel)
	{
		IssueResponseModel responseModel = new();

		var issue = await _db.Issues.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.Id);
		if (issue is null)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "No data found.";
			return responseModel;
		}

		var assignUser = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.AssignedTo);
		if (assignUser is null)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "User does not exist.";
			return responseModel;
		}

		issue.AssignedTo = assignUser.Id;
		_db.Entry(issue).State = EntityState.Modified;
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "Issue assignment successful" : "Issue assignment failed.";
		return responseModel;

	}

	public async Task<IssueListResponseModel> GetIssues()
	{
		IssueListResponseModel responseModel = new();

		var list = await _db.Issues.ToListAsync();

		responseModel.IsSuccess = true;
		responseModel.Message = "Success";
		responseModel.Data = list;
		return responseModel;
	}
}
