using MiniIssueTrackingSystemV2.Database.Models;
using MiniIssueTrackingSystemV2.Domain.Dtos;
using System.Collections.Generic;

namespace MiniIssueTrackingSystemV2.Domain.Util;

public static class DtoConverter
{
	public static UserDto ToDto(this UserModel model)
	{
		if (model is null) return null;
		return new UserDto
		{
			Id = model.Id,
			Username = model.Username,
			Email = model.Email,
		};
	}

	public static IssueDto ToDto(this IssueModel model)
	{
		return new IssueDto
		{
			Id = model.Id,
			Title = model.Title,
			Description = model.Description,
			Status = model.Status,
		};
	}

	public static CommentDto ToDto(this CommentModel model)
	{
		return new CommentDto
		{
			Id = model.Id,
			IssueId = model.IssueId,
			Text = model.Text,
		};
	}

	public static async Task<List<CommentDto>> ToDto(this List<CommentModel> modelList, Func<CommentModel, Task<UserModel>> getUser)
	{
		List<CommentDto> dtoList = new();

		foreach (var model in modelList)
		{
			CommentDto commentDto = new();

			var userModel = await getUser(model);
			commentDto.Id = model.Id;
			commentDto.IssueId = model.IssueId;
			commentDto.Text = model.Text;
			commentDto.CreatedBy = userModel.ToDto();
			dtoList.Add(commentDto);
		}

		return dtoList;
	}

}