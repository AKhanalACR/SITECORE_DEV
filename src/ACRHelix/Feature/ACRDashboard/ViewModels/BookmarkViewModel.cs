using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.ACRDashboard.ViewModels
{
  public class BookmarkViewModel
  {
    public Entity.Bookmark Bookmark { get; set; }
    public Entity.RecommendedArticle Article { get; set; }

    public string Title { get; set; }

    public string Url { get; set; }
  }
}