using ACRHelix.Feature.MembershipTestimonials.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.MembershipTestimonials.Models
{
    public interface ITestimonialsByCategory : ICMSEntity
    {
        ID Id { get; set; }

        [SitecoreField("Title")]
        string Title { get; set; }

        [SitecoreField("Number of Items to Display")]
        int NbrToItemsToDisplay { get; set; }

        [SitecoreField("Category")]
        string Category { get; set; }

        [SitecoreField("ArchiveLink")]
        Link ArchiveLink { get; set; }

        [SitecoreQuery("/sitecore/content/ACR//*[@@templateid='{F8C25D64-FEA9-49A2-A763-78DF7A277FF8}']")]
        IEnumerable<ITestimonial> Testimonials { get; set; }
    }
}