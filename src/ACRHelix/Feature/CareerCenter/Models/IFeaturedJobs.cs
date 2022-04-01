using ACRHelix.Feature.CareerCenter.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.CareerCenter.Models
{
    public interface IFeaturedJobs : ICMSEntity
    {
        Guid Id { get; set; }

        string Title { get; set; }

        [SitecoreField("Jobs Feed Url")]
        string JobsFeedUrl { get; }

        [SitecoreField("Items to Display")]
        int ItemsToDisplay { get; set; }
    }
}