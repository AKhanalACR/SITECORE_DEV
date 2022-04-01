using Glass.Mapper.Sc.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.ImageWiselyContent.Models.Configuration
{
    public class ImageWiselyContentMap : SitecoreGlassMap<IImageWiselyContent> /**/
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
