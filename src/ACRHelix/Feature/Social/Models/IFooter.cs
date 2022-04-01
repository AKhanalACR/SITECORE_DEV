using ACRHelix.Feature.Social.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.Social.Models
{
  public interface IFooter : ICMSEntity
  {
    Guid Id { get; set; }
    string Title { get; set; }
    Image Image { get; set; }

    [SitecoreField(FieldName = "Engage Link")]
    Link EngageLink { get; set; }
  }
}