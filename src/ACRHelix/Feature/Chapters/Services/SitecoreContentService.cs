using System;
using ACRHelix.Feature.Chapters.Models;
using ACRHelix.Foundation.Repository.Content;


namespace ACRHelix.Feature.Chapters.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public IChapters GetChaptersContent(string contentGuid)
    {
      return _repository.GetContentItem<IChapters>(contentGuid);
    }

    public ChapterAwardFolder GetChapterAwards(string contentGuid)
    {
      return _repository.GetContentItem<ChapterAwardFolder>(contentGuid);
    }

    public ChapterMeetingsFolder GetChapterMeetingsFolder(string contentGuid)
    {
      return _repository.GetContentItem<ChapterMeetingsFolder>(contentGuid);
    }

    public ChapterNewsFolder GetChapterNewsFolder(string contentGuid)
    {
      return _repository.GetContentItem<ChapterNewsFolder>(contentGuid);
    }

    public ChapterMeeting GetChapterMeeting(string contentGuid)
    {
      return _repository.GetContentItem<ChapterMeeting>(contentGuid);
    }

    public CommitteeMemberList GetCommitteeMemberList(string contentGuid)
    {
      return _repository.GetContentItem<CommitteeMemberList>(contentGuid);
    }

    public ChapterMembers GetChapterMemberContent(string contentGuid)
    {
      return _repository.GetContentItem<ChapterMembers>(contentGuid);
    }
  }
}