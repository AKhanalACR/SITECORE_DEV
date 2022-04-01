using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;

namespace ACRHelix.Feature.RSSFeed.ViewModels
{
  public class RSSFeedViewModel
  {
    public RSSFeedViewModel()
    {
      feedItems = new List<RSSFeedItemViewModel>();
    }

    public List<RSSFeedItemViewModel> feedItems { get; set; }
  }
}