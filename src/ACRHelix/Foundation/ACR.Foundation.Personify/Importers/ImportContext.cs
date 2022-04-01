using ACR.Foundation.Personify.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Importers
{
  public class ImportContext : IDisposable
  {
    private static readonly object importLock = new object();
    private static ImportContext _currentContext;

    public static ImportContext Current
    {
      get
      {
        return _currentContext;
      }
    }

    public static void InitializeRunImport(bool updateAll)
    {
      lock (importLock)
      {
        try
        {
          if (_currentContext != null)
          {
            PersonifyLogger.Logger.Error("Cannot start import, import is currently running.");
            return;
          }
          else
          {
            _currentContext = new ImportContext();

            PersonifyTaxonomyImporter taxonomyImporter = new PersonifyTaxonomyImporter();
            var results = taxonomyImporter.ImportItems();
            PersonifyLogger.Logger.Info("Taxonomy import results: " + string.Join(" - ", results));

            PersonifyProductImporter productImporter = new PersonifyProductImporter();
            var productResult = productImporter.ExecuteProductImport(updateAll);
           
            PersonifyLogger.Logger.Info("Product Import Results: " + string.Join(" -- ",productResult));
          }
        }
        catch (Exception ex)
        {
          PersonifyLogger.Logger.Error("Cannot during Personify Import", ex);
        }
        finally
        {
          _currentContext.Dispose();
        }
      }
    }

    public void Dispose()
    {
      PersonifyLogger.Logger.Info("Disposing Import Context");
      _currentContext = null;
    }
  }
}