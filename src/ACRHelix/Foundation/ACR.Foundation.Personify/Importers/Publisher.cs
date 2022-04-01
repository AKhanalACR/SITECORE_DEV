using ACR.Foundation.Personify.Logger;
using Sitecore;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Publishing;
using Sitecore.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ACR.Foundation.Personify.Importers
{



  public static class Publisher
  {
    public static void SmartPublishItems(ID rootItemId)
    {
      try
      {
        string[] dbs = Sitecore.Configuration.Factory.GetDatabaseNames();
       //get databases
        Database sourceDb;
        List<Database> targetDbs = new List<Database>();

        if (dbs.Contains("master"))
        {
          sourceDb = Sitecore.Configuration.Factory.GetDatabase("master");
        }
        else
        {
          PersonifyLogger.Logger.Error("Cannot find source database: master");
          return;
        }

        if (dbs.Contains("web"))
        {
          Database web = Sitecore.Configuration.Factory.GetDatabase("web");
          targetDbs.Add(web);
        }

        if (dbs.Contains("preview"))
        {
          Database preview = Sitecore.Configuration.Factory.GetDatabase("preview");
          targetDbs.Add(preview);
        }

        if (targetDbs.Count == 0)
        {
          PersonifyLogger.Logger.Error("Cannot find target databases");
          return;
        }

        Item root = sourceDb.GetItem(rootItemId);
        if (root == null)
        {
          PersonifyLogger.Logger.Error("Publishing failed - Cannot find root item with ID: " + rootItemId.ToString());
          return;
        }
        Handle handle = PublishManager.PublishItem(root, targetDbs.ToArray(), root.Languages, true, true, false);
        while (!PublishManager.GetStatus(handle).IsDone)
        {
          PersonifyLogger.Logger.Debug("Waiting for publishing to complete...");
          Thread.Sleep(10000);
        }
      }
      catch (Exception ex)
      {
        PersonifyLogger.Logger.Error("Error publishing items under: " + rootItemId.ToString(), ex);
      }

    }
  }
}