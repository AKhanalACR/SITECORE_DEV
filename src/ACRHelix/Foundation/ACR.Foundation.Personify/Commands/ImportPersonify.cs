using Sitecore;
using Sitecore.Shell.Framework.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ACR.Foundation.Personify.Commands
{
  public class ImportPersonify : Command
  {
    public override void Execute(CommandContext context)
    {
      string controlUrl = UIUtil.GetUri("control:xmlPersonifyImportManager");
      Context.ClientPage.ClientResponse.Broadcast(Context.ClientPage.ClientResponse.ShowModalDialog(controlUrl), "Shell");
    }
  }
}