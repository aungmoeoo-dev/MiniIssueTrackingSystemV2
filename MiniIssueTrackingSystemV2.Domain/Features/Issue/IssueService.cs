using Microsoft.EntityFrameworkCore;
using MiniIssueTrackingSystemV2.Database;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Issue.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.Issue;

public class IssueService : IIssueService
{
	private readonly AppDbContext _db;

	public IssueService()
	{
		_db = new AppDbContext();
	}

	public async Task<IssueCreateResponseModel> CreateIssue(IssueModel requestModel)
	{
		IssueCreateResponseModel responseModel = new();

		requestModel.Id = Guid.NewGuid().ToString();
		requestModel.Status = IssueStatus.Open;
		_db.Issues.Add(requestModel);
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "Issue creation successful." : "User creation failed.";
		responseModel.Data = result > 0 ? requestModel : null;
		return responseModel;
	}

	public async Task<IssueResponseModel> ChangeStatus(IssueModel requestModel)
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

	public async Task<IssueResponseModel> AssignIssue(IssueModel requestModel)
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
}
