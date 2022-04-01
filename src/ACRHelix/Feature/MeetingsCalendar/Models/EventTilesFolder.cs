using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ACRHelix.Foundation.Model;
using Glass.Mapper.Sc.Configuration.Attributes;
using Sitecore.Data;

namespace ACRHelix.Feature.MeetingsCalendar.Models
{
  public class EventTilesFolder : ICMSEntity
  {
    public virtual ID Id { get; set; }
    [SitecoreField("Header Text")]
    public virtual string HeaderText { get; set; }

    [SitecoreChildren]
    public virtual IEnumerable<EventTile> Children { get; set; }
  }
}