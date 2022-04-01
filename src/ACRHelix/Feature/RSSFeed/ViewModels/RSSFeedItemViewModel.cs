using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.RSSFeed.ViewModels
{
  public class RSSFeedItemViewModel
  {
    public RSSFeedItemViewModel(string _title, string _link, string _content)
    {
      title = _title;
      link = _link;
      content = _content;
    }

    public String title { get; set; }
    public String link { get; set; }
    public String content { get; set; }
  }
}