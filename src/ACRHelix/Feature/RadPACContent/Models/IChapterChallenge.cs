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
    public interface IChapterChallenge : ICMSEntity
    {
        ID Id { get; set; }

        [SitecoreChildren]
        IEnumerable<IChapter> Chapters { get; set; }
    }
}