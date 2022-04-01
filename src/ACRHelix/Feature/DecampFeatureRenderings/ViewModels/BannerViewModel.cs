using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DecampFeatureRenderings.ViewModels
{
  public class BannerViewModel
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Richtext { get; set; }

    public Link BannerLink { get; set; }

    public Image BannerImage { get; set; }
  }
}