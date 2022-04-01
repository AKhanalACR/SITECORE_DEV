using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;

namespace RHEC.Website.Models
{
  [SitecoreType(AutoMap = true)]
  public interface IButton : ICMSEntity
  {
    Guid Id { get; set; }
    string Text { get; set; }
    Link Link { get; set; }
  }
}