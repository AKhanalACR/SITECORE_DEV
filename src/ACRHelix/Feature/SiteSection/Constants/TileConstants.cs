using Sitecore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Feature.SiteSection.Constants
{
  public struct TileConstants
  {
    public struct Templates
    {
      public struct TileBaseTemplate
      {
        public static ID ID = new ID("{8A90A5C2-CE1F-4117-82B1-392B42CABD8E}");

       
      }

      public struct MeetingOrCourse
      {
        public static ID ID = new ID("{6C0A1097-31B1-4406-8922-D5D4BB9E8925}");
      }

      public struct ExternalTileTemplate
      {
        public static ID ID = new ID("{E636BAEC-B315-469A-AB04-C5711840262F}");
      }

      public struct TileHolder
      {
        public static ID ID = new ID("{9F0A9EEC-5F72-4004-854A-646EB6343EC6}");

        public struct Fields
        {
          public static ID Tiles = new ID("{20348D6A-B50A-4080-A50E-5FD84BC9C97B}");
        }
      }
    }

    public struct Renderings
    {

      public static string[] TileRenderingIDs = new string[] { HoverTileHolder.ID.ToString(), TileHolder.ID.ToString(), LaunchpadList.ID.ToString() };

      public struct HoverTileHolder
      {
        public static ID ID = new ID("{AE5F76F3-BB04-4263-9CAC-28607E38B207}");
      }

      public struct TileHolder
      {
        public static ID ID = new ID("{E094DBE1-FBCA-4415-BC7F-D4D412CC9760}");
      }

      public struct LaunchpadList
      {
        public static ID ID = new ID("{B2A71342-3A2D-4802-B3D6-528A9BBDAB6D}");
      }
    }
  }
}