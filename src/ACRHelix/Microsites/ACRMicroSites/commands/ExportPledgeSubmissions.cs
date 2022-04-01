using System.Web;
using ACR.Library.ImageWisely.Handlers;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;

namespace ACRMicroSites.commands
{
  public class ExportPledgeSubmissions : Command
  {
    public override void Execute(CommandContext context)
    {
      Item item = context.Items[0];

      string url = "https://" + HttpContext.Current.Request.Url.Host + ExportPledgeSubmissionsHandler.Url + "?id=" + item.ID.ToString();
      SheerResponse.Eval(string.Format("window.open('{0}', '_blank')", url));
    }

  }
}