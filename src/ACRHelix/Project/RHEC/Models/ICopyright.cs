using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;

namespace RHEC.Website.Models
{
  public interface ICopyright : ICMSEntity
  {
    Guid Id { get; set; }
    string Name { get; set; }
    [SitecoreField("Copyright")]
    string CopyrightText { get; set; }
    [SitecoreChildren]
    IEnumerable<ILinkMenuItem> MenuItems { get; set; }
  }
}