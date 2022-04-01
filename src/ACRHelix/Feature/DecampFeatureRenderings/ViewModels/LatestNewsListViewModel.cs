using ACRHelix.Feature.DecampFeatureRenderings.Models;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.ViewModels
{
  public class LatestNewsListViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }

    public Link Link { get; set; }

    public IEnumerable<INewsArticle> NewsArticlesList { get; set; }

  }
}