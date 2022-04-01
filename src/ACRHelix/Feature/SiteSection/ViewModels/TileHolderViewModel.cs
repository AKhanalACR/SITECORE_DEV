using Glass.Mapper.Sc.Configuration.Attributes;
using Glass.Mapper.Sc.Fields;
using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.ViewModels
{
  public class TileHolderViewModel
  {
    public ID Id { get; set; }
    public string Title { get; set; }
    public string LinkText { get; set; }
    public IEnumerable<TileViewModel> Tiles { get; set; }
    public int? TilesPerPage { get; set; }
    public int PageCount { get; set; }
    public int PageNumber { get; set; }
    public int TilesPerRow { get; set; }
    public string TileCssClass { get; set; }

    public int HiddenTiles { get; set; }

  }
}