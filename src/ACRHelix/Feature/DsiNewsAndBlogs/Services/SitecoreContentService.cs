using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Foundation.Repository.Content;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }

    public IRecentBlogList GetRecentBlogListContent(string contentGuid)
    {
      return _repository.GetContentItem<IRecentBlogList>(contentGuid);
    }

    public IBlogArchive GetBlogArchiveContent(string contentGuid)
    {
      return _repository.GetContentItem<IBlogArchive>(contentGuid);
    }

    public IBannerVideo GetBannerVideoContent(string contentGuid)
    {
      return _repository.GetContentItem<IBannerVideo>(contentGuid);
    }

    public IDsiLeadership GetDsiLeadershipContent(string contentGuid)
    {
      return _repository.GetContentItem<IDsiLeadership>(contentGuid);
    }

    public IDsiPageTitleWithImage GetPageTitleWithImageContent(string contentGuid)
    {
      return _repository.GetContentItem<IDsiPageTitleWithImage>(contentGuid);
    }

    public SignUpBlogUpdate GetBlogSignUpContent(string contentGuid)
    {
      return _repository.GetContentItem<SignUpBlogUpdate>(contentGuid);
    }

    public IExJsComponent GetExJsComponentContent(string contentGuid)
    {
      return _repository.GetContentItem<IExJsComponent>(contentGuid);
    }

    public ILatestItemSection GetLatestItemSection(string contentGuid)
    {
      return _repository.GetContentItem<ILatestItemSection>(contentGuid);
    }

    public ISubscription GetSubscriptionLink(string contentGuid)
    {
      return _repository.GetContentItem<ISubscription>(contentGuid);
    }

    public IRecentBlogPostList GetRecentBlogPostListContent(string contentGuid)
    {
      return _repository.GetContentItem<IRecentBlogPostList>(contentGuid);
    }
    public IFeaturedXBlogs GetFeaturedXBlogsContent(string contentGuid)
    {
      return _repository.GetContentItem<IFeaturedXBlogs>(contentGuid);
    }
  }
}