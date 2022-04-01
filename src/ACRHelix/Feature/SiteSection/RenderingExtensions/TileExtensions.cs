using Sitecore.Mvc.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.RenderingExtensions
{
  public static class TileExtensions
  {

    public static string GetTileColumnCss(this Rendering rendering)
    {
      string tileCss = "xl-col-3 lg-col-6 col-6";
      if (rendering != null)
      {
        if (rendering.Parameters["Columns"] != null)
        {
          if (!string.IsNullOrWhiteSpace(rendering.Parameters["Columns"]))
          {
            switch (rendering.Parameters["Columns"])
            {
              case "3 Column":
                tileCss = "xl-col-4 lg-col-6 col-6";

                break;
              case "4 Column":
                tileCss = "xl-col-3 lg-col-6 col-6";
                break;
              default:
                break;
            }
          }
        }
      }
      return tileCss;
    }

    public static int GetTilesPerRow(this Rendering rendering)
    {
      int tiles = 3;
      if (rendering != null)
      {
        if (rendering.Parameters["Columns"] != null)
        {
          if (!string.IsNullOrWhiteSpace(rendering.Parameters["Columns"]))
          {
            switch (rendering.Parameters["Columns"])
            {
              case "3 Column":
                tiles = 3;
                break;
              case "4 Column":
                tiles = 4;
                break;
              default:
                break;
            }
          }
        }
      }
      return tiles;
    }

  }
}