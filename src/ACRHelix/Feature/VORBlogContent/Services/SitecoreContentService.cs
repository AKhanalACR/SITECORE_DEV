using ACRHelix.Feature.VORBlogContent.Models;
using ACRHelix.Foundation.Repository.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.VORBlogContent.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public IVORFeaturedBlog GetVORFeaturedXBlogContent(string contentGuid)
    {
      return _repository.GetContentItem<IVORFeaturedBlog>(contentGuid);
    }

    public IVORSubscription GetVORSubscriptionLink(string contentGuid)
    {
      return _repository.GetContentItem<IVORSubscription>(contentGuid);
    }
  }
}