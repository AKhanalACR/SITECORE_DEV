using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RHEC.Website.Models
{
    public interface IPartnersLogo : ICMSEntity
    {
    Guid Id { get; set; }
    [SitecoreChildren]
    IEnumerable<ILogo> Partners { get; set; }
  }
}