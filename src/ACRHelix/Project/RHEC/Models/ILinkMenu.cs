using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;

namespace RHEC.Website.Models
{
  public interface ILinkMenu : ICMSEntity
  {
    Guid Id { get; set; }
    string Name { get; set; }
    [SitecoreField("Title")]
    string Title { get; set; }
    [SitecoreChildren]
    IEnumerable<ILinkMenuItem> MenuItems { get; set; }
  }
}