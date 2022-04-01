using System;
using System.Collections.Specialized;
using System.Threading;
using Sitecore;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using ACR.Foundation.Personify.Importers;
using System.Threading.Tasks;

namespace ACR.Foundation.Personify.SitecoreForms
{
  [Serializable]
  public class PersonifyImportManager : DialogForm
  {
    #region Properties
    protected Button btnRefreshProductsLatest;
    protected Button btnRefreshProductsAll;
    protected Literal litStatus;
    protected Literal litLatest;
    protected Literal litAll;
    #endregion

    protected override void OnLoad(EventArgs e)
    {
      base.OnLoad(e);
      if (Context.ClientPage.IsEvent)
      {
        return;
      }
      if (ImportContext.Current != null)
      {
        btnRefreshProductsLatest.Visible = false;
        btnRefreshProductsAll.Visible = false;
        litLatest.Visible = false;
        litAll.Visible = false;
        litStatus.Text =
            string.Format("There is currently an import running. Please wait until the current operation has completed.");
        return;
      }
      else
      {
        btnRefreshProductsLatest.Visible = true;
        btnRefreshProductsAll.Visible = true;
        litLatest.Visible = true;
        litAll.Visible = true;


        //using (var context = new ImportHelperDataContext())
        //{
        //  var record = context.GetLastSuccessfulImport();
        //  litStatus.Text = record == null
        //                       ? "There are no import records available. Click OK to start a new product import."
        //                       : string.Format(
        //                           "The last import successfully completed at {0} for products updated in Personify after {1}.",
        //                                          record.EndTime.GetValueOrDefault(DateTime.MinValue).ToString("yyyy/MM/dd HH:mm:ss"),
        //                                          record.MinDate.GetValueOrDefault(DateTime.MinValue).ToString("yyyy/MM/dd HH:mm:ss"));

        //}
      }
    }

    [HandleMessage("refreshProducts:latest")]
    protected void btnRefreshProductsLatest_Click(Message message)
    {
      Context.ClientPage.Start(this, "GetProducts", new NameValueCollection());
    }

    protected void GetProducts(ClientPipelineArgs args)
    {
      if (ImportContext.Current == null)
      {
        Task.Factory.StartNew(o => ImportContext.InitializeRunImport(false), TaskCreationOptions.LongRunning);
        //ThreadPool.QueueUserWorkItem(o => ImportContext.InitializeRunImport(false));
        SheerResponse.Alert("The import job has been started in a background thread.", new string[0]);
        SheerResponse.CloseWindow();
      }
    }

    [HandleMessage("refreshProducts:all")]
    protected void btnRefreshProductsAll_Click(Message message)
    {
      Context.ClientPage.Start(this, "RefreshProducts", new NameValueCollection());
    }

    protected void RefreshProducts(ClientPipelineArgs args)
    {
      if (args.IsPostBack)
      {
        if (args.Result == "no")
        {
          return;
        }
        if (ImportContext.Current == null)
        {
          //ThreadPool.QueueUserWorkItem(o => ImportContext.InitializeRunImport(true));
          Task.Factory.StartNew(o => ImportContext.InitializeRunImport(true), TaskCreationOptions.LongRunning);
          SheerResponse.Alert("The import job has been started in a background thread.", new string[0]);
          SheerResponse.CloseWindow();
        }
      }
      else
      {
        SheerResponse.Confirm("Are you sure you want to refresh all products?");
        args.WaitForPostBack();
      }
    }
  }
}
