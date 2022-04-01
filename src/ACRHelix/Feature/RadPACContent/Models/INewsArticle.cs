using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;

namespace ACRHelix.Feature.RadPACContent.Models
{
   
    public interface INewsArticle : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        string SubTitle { get; set; }
        string RichText { get; set; }
        string Topic { get; set; }
        string Author { get; set; }
        DateTime Date { get; set; }
        string Url { get; set; }
        [SitecoreField("Link Override")]
        string LinkOverride { get; set; }

    }
}