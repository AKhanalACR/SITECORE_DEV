using ACRHelix.Feature.PageContent.Models;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.ViewModels
{
  public class WelcomeHubViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public Image Image { get; set; }
    public Link Link { get; set; }
    public string BgColor { get; set; }
    public IEnumerable<IWelcomeHubItem> WelcomeHubItems { get; set; }
  }
}