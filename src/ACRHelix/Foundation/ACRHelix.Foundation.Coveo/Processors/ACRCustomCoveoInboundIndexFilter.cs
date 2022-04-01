using Coveo.SearchProvider.InboundFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coveo.SearchProvider.Pipelines;
using Sitecore.Foundation.SitecoreExtensions.Extensions;
using Sitecore.Data;

namespace ACRHelix.Foundation.CustomCoveo.Processors
{
  public class ACRCustomCoveoInboundIndexFilter : AbstractCoveoInboundFilterProcessor
  {

    private static string[] ExcludedTemplateIds = new string[]
    {
      "{2B60D99B-DC24-4848-8776-A58F75969670}", //staff directory page
      "{9246FCDE-D9A7-4C29-8544-4D36A8F185EB}", //staff directory
      "{DF09F9E1-4A1E-4A94-A74B-8A3FA8FCBFA4}", //Biography    
    };

    public override void Process(CoveoInboundFilterPipelineArgs args)
    {
      if (args.IndexableToIndex != null && !args.IsExcluded && ShouldExecute(args))
      {
        var fullPath = args.IndexableToIndex.Item.Paths.FullPath;
        if (fullPath.Contains("/NOINDEX/") || fullPath.Contains("ACR/Staging Pages/") || fullPath.Contains("ACR/Sample Pages/"))
        {
          args.IsExcluded = true;
          return;
        }

        //if (args.IndexableToIndex.SitecoreIndexableItem.Item.IsDerived(SitecoreConstants.Templates.AccessandEntitlements.TemplateID))
        //{
        //  string value = args.IndexableToIndex.Item.GetFieldValue(new ID(SitecoreConstants.Templates.AccessandEntitlements.Fields.DisplaySearchResults));
        //  if (value != "1")
        //  {
        //    args.IsExcluded = true;
        //    return;
        //  }
        //}

        if (ExcludedTemplateIds.Contains(args.IndexableToIndex.SitecoreIndexableItem.Item.TemplateID.ToString()))
        {
          args.IsExcluded = true;
          return;
        }
        
      }
    }
  }
}