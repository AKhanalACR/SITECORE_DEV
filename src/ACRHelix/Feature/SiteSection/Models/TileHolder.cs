using ACRHelix.Feature.SiteSection.Models;
using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Models
{
  public class TileHolder : ITileHolder
  {
    public virtual ID Id { get; set; }
    public virtual string Title { get; set; }


    //public string LinkText { get; set; }
    public virtual IEnumerable<ITile> Tiles { get; set; }
    public virtual int? TilesPerPage { get; set; }

    public virtual bool DisplayAllChildren { get; set; }

  }
}