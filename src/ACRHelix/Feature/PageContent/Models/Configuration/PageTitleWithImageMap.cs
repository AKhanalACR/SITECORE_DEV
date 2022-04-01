using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.PageContent.Models.Configuration
{
    public class PageTitleWithImageMap : SitecoreGlassMap<IPageTitleWithImage>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                //config.Id(f => f.Id);
            });
        }
    }
}
