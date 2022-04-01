using ACRHelix.Feature.DsiNewsAndBlogs.Models;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.DsiNewsAndBlogs.Models
{
    public interface IBlogArchive : ICMSEntity
    {
        Guid Id { get; }
        string Title { get; }

        string Type { get; set; }
      
        [SitecoreQuery("/sitecore/content/DSI//*[@@templateid='{C111CE1C-2DC0-47C4-9385-715606F88A24}']")]
        IEnumerable<NewsArticle> Articles { get; set; }

        [SitecoreField("Display Number")]
        int DisplayNumber { get; set; }
    }
}