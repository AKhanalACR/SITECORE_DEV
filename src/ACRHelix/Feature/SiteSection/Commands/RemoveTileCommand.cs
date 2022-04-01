using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data.Fields;
using Sitecore.Layouts;
using System.Xml.Linq;
using Sitecore.Data;
using Sitecore.Data.Items;
using static ACRHelix.Feature.SiteSection.Constants.TileConstants;

namespace ACRHelix.Feature.SiteSection.Commands
{
  public class RemoveTileCommand : Command
  {
    public override void Execute(CommandContext context)
    {
      var item = context.Items[0];
      if (item != null)
      {
        if (item.Database.Name == "master")
        {
          var database = item.Database;
          if (item.IsDerived(Templates.TileBaseTemplate.ID)) //tile content template
          {
            if (item.TemplateID == Templates.ExternalTileTemplate.ID)
            {
              RemoveTileFromDatasoure(item.Parent, item.ID);
            }
            else
            {
              var pageId = HttpContext.Current.Request.QueryString["id"];
              if (!string.IsNullOrWhiteSpace(pageId))
              {
                var pageItem = database.GetItem(pageId);
                var finalLayoutField = new LayoutField(pageItem.Fields[Sitecore.FieldIDs.FinalLayoutField]);
                var finalLayoutDefinition = LayoutDefinition.Parse(finalLayoutField.Value);

                XDocument layoutXml = XDocument.Parse(finalLayoutDefinition.ToXml());
                //string[] renderingIds = new string[] { HoverTileHolder_RenderingID, TileHolder_RenderingID, LaunchpadList_RenderingID };
                var rendering = layoutXml.Descendants("r").Where(x => Renderings.TileRenderingIDs.Contains((string)x.Attribute("id")));
                foreach (var r in rendering)
                {
                  string ds = r.Attribute("ds").Value;
                  if (!string.IsNullOrWhiteSpace(ds))
                  {
                    var datasourceID = new ID();
                    if (ID.TryParse(ds, out datasourceID))
                    {
                      var dataSource = database.GetItem(datasourceID);
                      if (dataSource != null)
                      {
                        RemoveTileFromDatasoure(dataSource, item.ID);
                      }
                    }
                  }
                }
              }
            }
          }
        }
      }
    }

    private void RemoveTileFromDatasoure(Item datasourceItem, ID removeId)
    {
      datasourceItem.Editing.BeginEdit();
      MultilistField tiles = datasourceItem.Fields[Templates.TileHolder.Fields.Tiles];
      tiles.Remove(removeId.ToString());
      datasourceItem.Editing.EndEdit();
    }
  }
}