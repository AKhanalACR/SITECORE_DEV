using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    [SitecoreType]
    public interface IFeaturedCarouselItems : ICMSEntity
    {
        [SitecoreField("Carousel Items")]
        IEnumerable<CarouselItem> CarouselItems { get; set; }
    }
}
