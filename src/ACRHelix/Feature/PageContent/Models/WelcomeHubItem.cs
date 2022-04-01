using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{
  public class WelcomeHubItem : IWelcomeHubItem
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public Image Icon { get; set; }
    public Link Link { get; set; }
    public string IconSymbol { get; set; }
    public bool UseIconImage { get; set; }
  }
}