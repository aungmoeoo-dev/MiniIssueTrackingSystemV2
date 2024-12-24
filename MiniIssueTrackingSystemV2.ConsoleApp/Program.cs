// See https://aka.ms/new-console-template for more information

using MiniIssueTrackingSystemV2.ConsoleApp.Features;

IssueTrackingSystemService issueTrackingSystemService = new IssueTrackingSystemService();

await issueTrackingSystemService.Run();