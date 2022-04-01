using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static ACRHelix.Feature.SiteSection.Constants.TileConstants;

namespace ACRHelix.Feature.SiteSection.Pipelines
{
  public class ExternalTileSavedProcessor
  {
    public void OnItemSaved(object sender, EventArgs args)
    {
      SitecoreEventArgs eventArgs = args as SitecoreEventArgs;
      Sitecore.Diagnostics.Assert.IsNotNull(eventArgs, "eventArgs");
      Item item = eventArgs.Parameters[0] as Item;
      if (item != null)
      {
        if (item.Database.Name == "master")
        {
          //only if external tile content
          if (item.TemplateID == Templates.ExternalTileTemplate.ID)
          {
            var id = item.ID;
            var created = item.Statistics.Created;

            if (DateTime.UtcNow.AddMinutes(-2) <= created)
            {
              var tileHolder = item.Parent;
              //if parent is tile holder
              if (tileHolder.TemplateID == Templates.TileHolder.ID)
              {
                tileHolder.Editing.BeginEdit();
                MultilistField tileField = tileHolder.Fields[Templates.TileHolder.Fields.Tiles];
                if (!tileField.TargetIDs.Contains(id))
                {
                  tileField.Add(id.ToString());
                }
                tileHolder.Editing.EndEdit();
              }
            }
          }
        }
      }

    }
  }
}