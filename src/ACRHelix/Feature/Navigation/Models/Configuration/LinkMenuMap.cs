using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.Navigation.Models.Configuration
{
    public class LinkMenuMap : SitecoreGlassMap<ILinkMenu>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                //config.Field(f => f.Title).FieldName("Title");
            });
        }
    }
}
