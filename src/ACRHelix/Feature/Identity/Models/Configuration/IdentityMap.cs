using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.Identity.Models.Configuration
{
    public class IdentityMap : SitecoreGlassMap<IIdentity>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                //config.Id(f => f.Id);
                //config.Field(f => f.Title).FieldName("Title");
            });
        }
    }
}
