using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    [SitecoreType]
    public interface ICarouselItem : ICMSEntity
    {
        string Title { get; set; }

        string Description { get; set; }

        [SitecoreField("Feature Link")]
        Link FeatureLink { get; set; }

        [SitecoreField("Feature Image")]
        Image FeatureImage { get; set; }
    }
}
