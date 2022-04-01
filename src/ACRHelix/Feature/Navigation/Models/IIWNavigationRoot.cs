using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.Models
{
  public interface IIWNavigationRoot : ICMSEntity
  {
    ID Id { get; }
    string Name { get; }
    [SitecoreChildren]
    IEnumerable<IWNavigableItem> Children { get; }
  }
}