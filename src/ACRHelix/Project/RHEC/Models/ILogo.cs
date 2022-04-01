using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;

namespace RHEC.Website.Models
{
  [SitecoreType(AutoMap = true)]
  public interface ILogo : ICMSEntity
  {
    Guid Id { get; set; }
    Link Link { get; set; }
    Image Image { get; set; }
  }
}