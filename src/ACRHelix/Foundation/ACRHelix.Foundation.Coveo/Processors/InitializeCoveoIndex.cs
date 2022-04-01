using ACRHelix.Foundation.CustomCoveo.Logger;
using Sitecore.ContentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACRHelix.Foundation.CustomCoveo.Processors
{
  public class InitalizeCoveoIndex
  {
    public void InitializeCoveoIndex()
    {
      CustomCoveoLogger.Logger.Error("Atempting to initilize Coveo Indexes manually");
      try
      {
        var masterIndex = ContentSearchManager.GetIndex("Coveo_master_index");
        masterIndex.Initialize();
      }
      catch (Exception ex)
      {
        CustomCoveoLogger.Logger.Error("Error Initializing Coveo Master Index before publish", ex);
      }

      try
      {
        var index = ContentSearchManager.GetIndex("Coveo_web_index");
        index.Initialize();
      }
      catch (Exception ex)
      {
        CustomCoveoLogger.Logger.Error("Error Initializing Coveo Web Index before publish", ex);
      }
    
    }

  }

}