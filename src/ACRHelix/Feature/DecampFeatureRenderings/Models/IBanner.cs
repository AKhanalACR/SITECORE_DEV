using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using ACRHelix.Foundation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.Models
{
  public interface IBanner : ICMSEntity
  {
    Guid Id { get; set; }

    string Title { get; set; }
    string Richtext { get; set; }

    Link BannerLink { get; set; }

    Image BannerImage { get; set; }
  }
}