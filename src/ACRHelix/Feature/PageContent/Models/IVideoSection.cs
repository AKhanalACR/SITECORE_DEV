using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface IVideoSection : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        Link VideoLink { get; set; }
        [SitecoreChildren]
        IEnumerable<VideoSection> Videos { get; set; }
    }
}