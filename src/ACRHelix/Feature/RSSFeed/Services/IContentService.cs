using ACRHelix.Feature.RSSFeed.Models;

namespace ACRHelix.Feature.RSSFeed.Services
{
  public interface IContentService
  {
    Models.RSSFeed GetRSSFeedContent(string contentGuid);
  }
}