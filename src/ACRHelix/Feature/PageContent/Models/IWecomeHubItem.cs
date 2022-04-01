using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.PageContent.Models
{
  public interface IWelcomeHubItem : ICMSEntity
  {
    ID Id { get; set; }
    string Title { get; set; }
    string SubTitle { get; set; }
    Image Icon { get; set; }
    Link Link { get; set; }
    string IconSymbol { get; set; }
    bool UseIconImage { get; set; }
  }
}