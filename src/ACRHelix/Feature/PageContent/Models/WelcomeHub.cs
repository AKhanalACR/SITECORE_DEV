using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{
  public class WelcomeHub : IWelcomeHub
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }
    public IEnumerable<IWelcomeHubItem> WelcomeHubItems { get; set; }
    public string BgColor { get ; set ; }
  }
}