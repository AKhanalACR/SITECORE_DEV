using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using Glass.Mapper.Sc.Fields;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public interface INewsArticle : ICMSEntity
    {
        Guid Id { get; }

        string Title { get; }

        string Type { get; set; }

        string SubTitle { get; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Author { get; set; }

        string Content { get; set; }

        string Url { get; set; }

        string Source { get; set; }

        IEnumerable<Guid> Tags { get; set; }

        [SitecoreField("Link Override")]
        string LinkOverride { get; set; }

        [SitecoreField("Tile Text")]
        string TileText { get; set; }

        Image Image { get; set; }
    }
}