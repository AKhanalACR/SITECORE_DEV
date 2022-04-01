using ACRHelix.Feature.RSSFeed.Services;
using ACRHelix.Feature.RSSFeed.ViewModels;
using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ACRHelix.Feature.RSSFeed
{
  public class RSSFeedController : Controller
  {
    private readonly IContentService _contentService;

    public RSSFeedController(IContentService contentService)
    {
      _contentService = contentService;
    }

    public ViewResult RSSFeed()
    {
      var viewModel = new RSSFeedViewModel();

      if (!String.IsNullOrEmpty(RenderingContext.Current.Rendering.DataSource))
      {
        var RSSFeedContent = _contentService.GetRSSFeedContent(RenderingContext.Current.Rendering.DataSource);
        if (RSSFeedContent != null)
        {
          XmlReader reader = XmlReader.Create(RSSFeedContent.feedURL);
          SyndicationFeed feed = SyndicationFeed.Load(reader);
          reader.Close();
          foreach (SyndicationItem item in feed.Items)
          {
            viewModel.feedItems.Add(new RSSFeedItemViewModel(item.Title.Text, item.Links.First().Uri.ToString(), item.Summary.Text));
          }
        }
      }

      return View("RSSFeed", viewModel);
    }
  }
}