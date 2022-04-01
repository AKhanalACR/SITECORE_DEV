using ACRHelix.Foundation.Repository.Content;
using ACRHelix.Feature.RSSFeed.Models;


namespace ACRHelix.Feature.RSSFeed.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public Models.RSSFeed GetRSSFeedContent(string contentGuid)
    {
      return _repository.GetContentItem<Models.RSSFeed>(contentGuid);
    }
  }
}