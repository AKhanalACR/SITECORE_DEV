
using ACRHelix.Feature.DecampFeatureRenderings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.Services
{
  public interface IContentService
  {
    IBanner GetBannerContent(string contentGuid);
    INewsList GetLatestNewsListContent(string contentGuid);

    IRichTextSection GetRichTextSectionContent(string contentGuid);

    ITextCalloutSection GetTextCalloutSectionContent(string contentGuid);

    IPageTitle GetPageTitleContent(string contentGuid);

  }
}