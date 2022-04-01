using ACRHelix.Feature.DsiNewsAndBlogs.Models;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Services
{
  public interface IContentService
  {
    IRecentBlogList GetRecentBlogListContent(string contentGuid);

    IBlogArchive GetBlogArchiveContent(string contentGuid);

    IBannerVideo GetBannerVideoContent(string contentGuid);

    IDsiLeadership GetDsiLeadershipContent(string contentGuid);

    IDsiPageTitleWithImage GetPageTitleWithImageContent(string contentGuid);

    Models.SignUpBlogUpdate GetBlogSignUpContent(string contentGuid);

    IExJsComponent GetExJsComponentContent(string contentGuid);

    ILatestItemSection GetLatestItemSection(string contentGuid);

    ISubscription GetSubscriptionLink(string contentGuid);

    IRecentBlogPostList GetRecentBlogPostListContent(string contentGuid);

    IFeaturedXBlogs GetFeaturedXBlogsContent(string contentGuid);
  }
}