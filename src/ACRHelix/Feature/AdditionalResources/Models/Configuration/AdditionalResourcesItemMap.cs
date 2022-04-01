using Glass.Mapper.Sc;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Maps;
using Sitecore.Data.Fields;
using Sitecore.Links;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.AdditionalResources.Models.Configuration
{
  public class AdditionalResourcesItemMap : SitecoreGlassMap<AdditionalResourcesItem>
  {
    public override void Configure()
    {
        Map(config =>
        {
          config.AutoMap();
        });
    }
  }
}
