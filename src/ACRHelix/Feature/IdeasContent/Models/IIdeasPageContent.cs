using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;


namespace ACRHelix.Feature.IdeasContent.Models
{
    public interface IIdeasPageContent : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string RichText { get; set; }
        [SitecoreField("Date")]
        DateTime Date { get; set; }

        [SitecoreField("Enable Share Link")]
        bool EnableShareLink { get; set; }

        IEnumerable<IdeasDictionaryEntry> Tags { get; set; }
    }
}