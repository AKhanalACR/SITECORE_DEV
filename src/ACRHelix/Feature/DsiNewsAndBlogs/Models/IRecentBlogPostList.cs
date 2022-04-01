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
    public interface IRecentBlogPostList : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }

        string Type { get; set; }

        [SitecoreField("ArchivesLink")]
        Link ArchivesLink { get; set; }

        [SitecoreQuery("/sitecore/content/DSI//*[@@templateid='{60776C24-BEB7-4193-A6DC-FA560A40A15B}']")]
        IEnumerable<BlogPost> BlogPosts { get; set; }

    [SitecoreQuery("/sitecore/content/DSI//*[@@templateid='{C111CE1C-2DC0-47C4-9385-715606F88A24}']")]
    IEnumerable<NewsArticle> Articles { get; set; }

    [SitecoreField("Display Number")]
        int DisplayNumber { get; set; }
    }
}