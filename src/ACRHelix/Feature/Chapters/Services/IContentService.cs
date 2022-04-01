using ACRHelix.Feature.Chapters.Models;


namespace ACRHelix.Feature.Chapters.Services
{
  public interface IContentService
  {
    IChapters GetChaptersContent(string contentGuid);
    ChapterAwardFolder GetChapterAwards(string contentGuid);
    ChapterMeetingsFolder GetChapterMeetingsFolder(string contentGuid);
    ChapterNewsFolder GetChapterNewsFolder(string contentGuid);

    ChapterMeeting GetChapterMeeting(string contentGuid);

    CommitteeMemberList GetCommitteeMemberList(string contentGuid);

    ChapterMembers GetChapterMemberContent(string contentGuid);
  }
}