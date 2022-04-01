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
    public interface IEventTiles : ICMSEntity
    {
        ID Id { get; set; }
        string Title { get; set; }
        [SitecoreField("Number of Tiles to Display")]
        int TilesDisplayNumber { get; set; }        
        Link Link { get; set; }

        [SitecoreChildren]
        //[SitecoreQuery("./*[@templateid='{13C20322-C005-4AED-8DE8-CA6275666AB5}']", IsRelative = true)]
        IEnumerable<IEventTile> Tiles { get; set; }
    }
}