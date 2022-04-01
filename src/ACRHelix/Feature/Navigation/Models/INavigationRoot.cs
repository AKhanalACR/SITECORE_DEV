using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.Navigation.Models
{
  public interface INavigationRoot : ICMSEntity
  {
    ID Id { get; }
    string Name { get; }
    [SitecoreChildren]
    IEnumerable<NavigableItem> Children { get; }
  }
}