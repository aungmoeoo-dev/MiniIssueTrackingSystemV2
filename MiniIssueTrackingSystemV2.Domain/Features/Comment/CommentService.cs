﻿using Microsoft.EntityFrameworkCore;
using MiniIssueTrackingSystemV2.Database;
using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Features.Comment.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniIssueTrackingSystemV2.Domain.Features.Comment;

public class CommentService : ICommentService
{
	private readonly AppDbContext _db;

	public CommentService()
	{
		_db = new AppDbContext();
	}

	public async Task<CommentResponseModel> CreateComment(CommentModel requestModel)
	{
		CommentResponseModel responseModel = new();

		requestModel.Id = Guid.NewGuid().ToString();
		_db.Comments.Add(requestModel);
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "Comment creation successful." : "Comment creation failed.";
		responseModel.Data = result > 0 ? requestModel : null;
		return responseModel;
	}

	public async Task<CommentResponseModel> UpdateComment(CommentModel requestModel)
	{
		CommentResponseModel responseModel = new();

		var comment = await _db.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.Id);
		if (comment is null)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "No data found.";
			return responseModel;
		}

		var commentOwner = await _db.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == requestModel.CreatedBy);
		if (commentOwner is null)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "User does not exist.";
			return responseModel;
		}

		if (commentOwner.Id != comment.CreatedBy)
		{
			responseModel.IsSuccess = false;
			responseModel.Message = "Unauthorized!";
			return responseModel;
		}

		comment.Text = requestModel.Text;
		_db.Entry(comment).State = EntityState.Modified;
		int result = await _db.SaveChangesAsync();

		responseModel.IsSuccess = result > 0;
		responseModel.Message = result > 0 ? "Comment updating successful." : "Comment updating failed.";
		responseModel.Data = result > 0 ? comment : null;
		return responseModel;
	}
}
