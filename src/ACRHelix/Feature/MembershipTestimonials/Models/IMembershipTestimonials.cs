using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public interface IMembershipTestimonials : ICMSEntity
    {

        ID Id { get; set; }
        string Title { get; set; }

        //[SitecoreField("Page Size")]
        int PageSize { get; set; }

        //[SitecoreField("FormUrl")]
        Link FormUrl { get; set; }

       // [SitecoreField("FormBlockTitle")]
        string FormBlockTitle { get; set; }

       // [SitecoreField("FormBlockButtonText")]
        string FormBlockButtonText { get; set; }

       // [SitecoreField("Featured Item")]
        ITestimonial FeaturedItem { get; set; }

       // [SitecoreField("BannerText")]
        string BannerText { get; set; }

       // [SitecoreField("BannerLinkText")]
        string BannerLinkText { get; set; }

       // [SitecoreField("Categories")]
        IEnumerable<ICategory> Categories { get; set; }

        [SitecoreQuery("./*/*[@@templateid = '{F8C25D64-FEA9-49A2-A763-78DF7A277FF8}']", IsRelative = true)]
        IEnumerable<ITestimonial> Testimonials { get; set; }
        
    }
}