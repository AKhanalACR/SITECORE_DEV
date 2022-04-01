using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Data;
using Glass.Mapper.Sc.Fields;
using Glass.Mapper.Sc.Configuration;

namespace ACRHelix.Feature.RadPACContent.Models
{
    public class EventTile : IEventTile
    {
        public ID Id { get; set; }
        public string TileText { get; set; }
        public Image Image { get; set; }
        public Link Link { get; set; } 
        public IEnumerable<IEventTag> Tags { get; set; }
    }
}