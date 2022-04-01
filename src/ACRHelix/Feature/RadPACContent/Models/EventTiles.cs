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
    public class EventTiles : IEventTiles
    {
        public ID Id { get; set; }
        public string Title { get; set; }

        [SitecoreField("Number of Tiles to Display")]
        public int TilesDisplayNumber { get; set; }
        public Link Link { get; set; }

        public IEnumerable<IEventTile> Tiles { get; set; }
    }
}