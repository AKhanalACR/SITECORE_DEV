using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public interface IRichtextSection : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string RichText { get; set; }

        string YouTubeEmbedUrl { get; set; }

        Image Image { get; set; }

        bool DefaultImageLocation { get; set; }

    }
}