using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface IRichTextSection : ICMSEntity
    {
        ID Id { get; }
        string Title { get; set; }
        string RichText { get; set; }
    }
}