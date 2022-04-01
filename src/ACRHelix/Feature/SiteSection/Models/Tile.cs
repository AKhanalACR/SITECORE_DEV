using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Models
{
    public class Tile : ITile
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TileText { get; set; }

    public string ShortTitle { get; set; }
    public Image Image { get; set; }
        public string Url { get; set; }
        public string LinkText { get; set; }
        public virtual Link Link { get; set; }
        public ID TemplateID { get; set; }
    }
}