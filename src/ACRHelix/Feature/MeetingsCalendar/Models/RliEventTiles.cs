using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore;
using Sitecore.Data;

namespace ACRHelix.Feature.MeetingsCalendar.Models
{
    public class RliEventTiles : ICMSEntity
    {
        public virtual ID Id { get; set; }

        [SitecoreField("Title")]
        public virtual string Title { get; set; }

        [SitecoreField("Number of Items to Display")]
        public virtual int NbrItemsToDisplay { get; set; }

        [SitecoreField("ArchiveLink")]
        public virtual Link ArchiveLink { get; set; }

        [SitecoreQuery("/sitecore/content/ACR/Personify/Product Stubs/MTG/RLI//*[@@templateid='{62BEEA1D-6B79-4E0C-A98F-E337E321DBBE}']")]
        public virtual IEnumerable<RliEventTile> EventTiles { get; set; }

    }
}