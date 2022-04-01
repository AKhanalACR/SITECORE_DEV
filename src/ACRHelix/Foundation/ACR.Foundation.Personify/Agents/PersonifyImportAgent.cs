using ACR.Foundation.Personify.Importers;
using ACR.Foundation.Personify.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ACR.Foundation.Personify.Agents
{
  public class PersonifyImportAgent
  {
    public void Run()
    {
      if (ImportContext.Current == null)
      {
        PersonifyLogger.Logger.Info("Starting Personify Import Agent");
        Task.Factory.StartNew(o => ImportContext.InitializeRunImport(false), TaskCreationOptions.LongRunning);
      }
      else
      {
        PersonifyLogger.Logger.Error("There is a Personify Import currently running. Product Import Agent aborting.");
      }
    }
  }
}