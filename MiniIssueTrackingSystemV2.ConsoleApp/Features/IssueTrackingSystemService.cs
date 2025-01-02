using MiniIssueTrackingSystemV2.ConsoleApp.Dtos;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.Auth;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.Comment.Model;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.Issue;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.Issue.Model;
using MiniIssueTrackingSystemV2.ConsoleApp.Features.User.Model;

namespace MiniIssueTrackingSystemV2.ConsoleApp.Features
{
	public class IssueTrackingSystemService
	{
		private UserDto loggedInUser = null;

		public async Task Run()
		{
			while (true)
			{
				if (loggedInUser == null)
				{
					await ShowLoginMenu();
				}
				else
				{
					await ShowMainMenu();
				}
			}
		}

		private async Task ShowLoginMenu()
		{
			Console.WriteLine("1. Register");
			Console.WriteLine("2. Login");
			Console.WriteLine("3. Exit");

			var choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					await RegisterUser();
					break;
				case "2":
					await LoginUser();
					break;
				case "3":
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Invalid choice. Try again.");
					break;
			}
		}

		private async Task ShowMainMenu()
		{
			Console.WriteLine("1. Create Issue");
			Console.WriteLine("2. View Issues");
			Console.WriteLine("3. Add Comment");
			Console.WriteLine("4. Change Issue Status");
			Console.WriteLine("5. Assign Issue");
			Console.WriteLine("6. Logout");

			var choice = Console.ReadLine();
			switch (choice)
			{
				case "1":
					await CreateIssue();
					break;
				case "2":
					await ViewIssues();
					break;
				case "3":
					await AddComment();
					break;
				case "4":
					await ChangeIssueStatus();
					break;
				case "5":
					await AssignIssue();
					break;
				case "6":
					loggedInUser = null;
					break;
				default:
					Console.WriteLine("Invalid choice. Try again.");
					break;
			}
		}

		private async Task RegisterUser()
		{
			Console.Write("Enter username: ");
			var username = Console.ReadLine();
			Console.Write("Enter email: ");
			var email = Console.ReadLine();

			if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
			{
				Console.WriteLine("Username and email cannot be empty.");
				return;
			}

			AuthService authService = new();
			var response = await authService.RegisterUser(new UserModel { Username = username, Email = email });

			Console.WriteLine(response.Message);
		}

		private async Task LoginUser()
		{
			Console.Write("Enter username: ");
			var username = Console.ReadLine();

			AuthService authService = new();
			var response = await authService.LoginUser(new UserModel { Username = username });

			loggedInUser = response.Data;

			if (loggedInUser != null)
			{
				Console.WriteLine("Login successful.");
			}
			else
			{
				Console.WriteLine("User not found.");
			}
		}

		private async Task CreateIssue()
		{
			if (loggedInUser == null)
			{
				Console.WriteLine("You need to log in first.");
				return;
			}

			Console.Write("Enter issue title: ");
			var title = Console.ReadLine();
			Console.Write("Enter issue description: ");
			var description = Console.ReadLine();

			if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(description))
			{
				Console.WriteLine("Title and description cannot be empty.");
				return;
			}

			IssueService issueService = new();
			var response = await issueService.CreateIssue(new IssueModel { Title = title, Description = description, CreatedBy = loggedInUser.Id });

			Console.WriteLine(response.Message);
		}

		private async Task ViewIssues()
		{
			IssueService issueService = new();
			var response = await issueService.GetIssues();

			foreach (var issue in response.Data)
			{
				Console.WriteLine(issue);
			}
		}

		private async Task AddComment()
		{
			Console.Write("Enter issue ID: ");
			string issueId = Console.ReadLine()!;

			Console.Write("Enter comment: ");
			var comment = Console.ReadLine();

			if (string.IsNullOrEmpty(comment))
			{
				Console.WriteLine("Comment cannot be empty.");
				return;
			}

			CommentService commentService = new();
			var response = await commentService.CreateComment(new CommentModel { IssueId = issueId, Text = comment, CreatedBy = loggedInUser.Id });

			Console.WriteLine(response.Message);
		}

		private async Task ChangeIssueStatus()
		{
			Console.Write("Enter issue ID: ");
			string issueId = Console.ReadLine()!;

			Console.WriteLine("Select new status:");
			Console.WriteLine("1. Open");
			Console.WriteLine("2. In Progress");
			Console.WriteLine("3. Resolved");
			Console.WriteLine("4. Closed");

			var statusChoice = Console.ReadLine();
			IssueStatus newStatus;

			switch (statusChoice)
			{
				case "1":
					newStatus = IssueStatus.Open;
					break;
				case "2":
					newStatus = IssueStatus.InProgress;
					break;
				case "3":
					newStatus = IssueStatus.Resolved;
					break;
				case "4":
					newStatus = IssueStatus.Closed;
					break;
				default:
					Console.WriteLine("Invalid status choice.");
					return;
			}

			IssueService issueService = new();
			var response = await issueService.ChangeIssueStatus(new IssueModel { Id = issueId, Status = newStatus, CreatedBy = loggedInUser.Id });

			Console.WriteLine(response.Message);
		}

		private async Task AssignIssue()
		{
			Console.Write("Enter issue ID: ");
			string issueId = Console.ReadLine()!;

			Console.Write("Enter username to assign: ");
			var username = Console.ReadLine();

			IssueService issueService = new();
			var response = await issueService.AssignIssue(new IssueModel { Id = issueId, CreatedBy = loggedInUser.Id, AssignedTo = username });
			Console.WriteLine(response.Message);
		}
	}
}
