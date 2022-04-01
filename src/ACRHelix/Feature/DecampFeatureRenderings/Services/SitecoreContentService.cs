using ACRHelix.Foundation.Repository.Content;
using ACRHelix.Feature.DecampFeatureRenderings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.Services
{
  public class SitecoreContentService : IContentService
  {
    private readonly IContentRepository _repository;
    public SitecoreContentService(IContentRepository repository)
    {
      _repository = repository;
    }
    public IBanner GetBannerContent(string contentGuid)
    {
      return _repository.GetContentItem<IBanner>(contentGuid);
    }

    public INewsList GetLatestNewsListContent(string contentGuid)
    {
      return _repository.GetContentItem<INewsList>(contentGuid);
    }

    public IRichTextSection GetRichTextSectionContent(string contentGuid)
    {
      return _repository.GetContentItem<IRichTextSection>(contentGuid);
    }

    public ITextCalloutSection GetTextCalloutSectionContent(string contentGuid)
    {
      return _repository.GetContentItem<ITextCalloutSection>(contentGuid);
    }

    public IPageTitle GetPageTitleContent(string contentGuid)
    {
      return _repository.GetContentItem<IPageTitle>(contentGuid);
    }

  }
}