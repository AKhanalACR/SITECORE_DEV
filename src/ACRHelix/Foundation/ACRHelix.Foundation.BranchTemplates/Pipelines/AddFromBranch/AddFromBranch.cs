using System;
using System.Linq;
using System.Web.Mvc;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;
using Sitecore.Pipelines.ItemProvider.AddFromTemplate;
using Sitecore.Data.Items;
using Sitecore;
using ACRHelix.Foundation.BranchTemplates.Pipelines.AddFromBranch;
using Sitecore.StringExtensions;

namespace ACRHelix.Foundation.BranchTemplates.Pipelines.AddFromBranch
{

  public class AddFromBranch : Sitecore.Pipelines.ItemProvider.AddFromTemplate.AddFromTemplateProcessor
  {
    public override void Process(AddFromTemplateArgs args)
    {
      Assert.ArgumentNotNull(args, nameof(args));

      if (args.Destination.Database.Name != "master") return;

      var templateItem = args.Destination.Database.GetItem(args.TemplateId);

      Assert.IsNotNull(templateItem, "Template did not exist!");

      // if this isn't a branch template, we can use the stock behavior
      if (templateItem.TemplateID != TemplateIDs.BranchTemplate) return;

      Assert.HasAccess((args.Destination.Access.CanCreate() ? 1 : 0) != 0, "AddFromTemplate - Add access required (destination: {0}, template: {1})", args.Destination.ID, args.TemplateId);

      // Create the branch template instance
      Item newItem = args.Destination.Database.Engines.DataEngine.AddFromTemplate(args.ItemName, args.TemplateId, args.Destination, args.NewId);

      unProtectItem(newItem);
    

      // find all rendering data sources on the branch root item that point to an item under the branch template,
      // and repoint them to the equivalent subitem under the branch instance
      RewriteBranchRenderingDataSources(newItem, newItem, templateItem);

      // now go through all descendants to translate their data sources
      var newItemDescendants = newItem.Axes.GetDescendants();
      for (int i = 0; i < newItemDescendants.Length; i++)
      {
        RewriteBranchRenderingDataSources(newItemDescendants[i], newItem, templateItem);
        unProtectItem(newItemDescendants[i]);
      }

      args.Result = newItem;
    }

    private void unProtectItem(Item item)
    {
      if (item.Appearance.ReadOnly)
      {
        using (new StatisticDisabler(StatisticDisablerState.ForItemsWithoutVersionOnly))
        {
          item.Editing.BeginEdit();
          item.Appearance.ReadOnly = false;
          item.Editing.EndEdit();
        }
      }
    }

    protected virtual void RewriteBranchRenderingDataSources(Item item, Item baseItem, BranchItem branchTemplateItem)
    {
      string branchBasePath = branchTemplateItem.InnerItem.Paths.FullPath;

      LayoutHelper.ApplyActionToAllRenderings(item, rendering =>
      {
        if (string.IsNullOrWhiteSpace(rendering.Datasource))
          return RenderingActionResult.None;

        // note: queries and multiple item datasources are not supported
        var renderingTargetItem = item.Database.GetItem(rendering.Datasource);

        if (renderingTargetItem == null)
          Log.Warn("Error while expanding branch template rendering datasources: data source {0} was not resolvable.".FormatWith(rendering.Datasource), this);

        // if there was no valid target item OR the target item is not a child of the branch template we skip out
        if (renderingTargetItem == null || !renderingTargetItem.Paths.FullPath.StartsWith(branchBasePath, StringComparison.OrdinalIgnoreCase))
          return RenderingActionResult.None;

        var relativeRenderingPath = renderingTargetItem.Paths.FullPath.Substring(branchBasePath.Length).TrimStart('/');

        int pathSlash = relativeRenderingPath.IndexOf('/');

        if (pathSlash > 0)
        {
          relativeRenderingPath = relativeRenderingPath.Substring(pathSlash); // we need to skip the "/$name" at the root of the branch children
        }

        var newTargetPath = baseItem.Paths.FullPath.TrimEnd('/') + relativeRenderingPath;
        //item.Paths.FullPath.Replace("Home", "").Replace("Global", "").TrimEnd('/') + relativeRenderingPath;       

        var newTargetItem = item.Database.GetItem(newTargetPath);

        // if the target item was a valid under branch item, but the same relative path does not exist under the branch instance
        // we set the datasource to something invalid to avoid any potential unintentional edits of a shared data source item
        if (newTargetItem == null)
        {
          rendering.Datasource = string.Empty;
          return RenderingActionResult.None;
        }

        rendering.Datasource = newTargetItem.ID.ToString();
        return RenderingActionResult.None;
      });
    }
  }
}
