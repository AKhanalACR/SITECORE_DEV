using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.IdeasContent.Models
{
    public interface IIdeasRichText : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string RichText { get; set; }
    }
}