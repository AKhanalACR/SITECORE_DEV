using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.PageContent.Models
{
    public interface ILinkSectionItem : ICMSEntity
    {
        ID Id { get; }
        string Title { get; set; }
        string Url { get; set; }
        string Extension { get; set; }
        bool Equals(object other);
        int GetHashCode();
    }
}