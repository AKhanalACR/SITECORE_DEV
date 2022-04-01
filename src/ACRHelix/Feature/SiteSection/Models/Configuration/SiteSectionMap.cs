using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.SiteSection.Models.Configuration
{
    public class SiteSectionMap : SitecoreGlassMap<ISiteSection>
    {
        public override void Configure()
        {
            Map(config =>
            {
                //config.AutoMap();
                //config.HeaderImage(f => f.HeaderImage);
                //config.Id(f => f.Id);
                config.Field(f => f.HeaderImage).FieldName("Header Image");
            });
        }
    }
}
