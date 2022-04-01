using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Web.UI.Sheer;
using System;

namespace ACR.Foundation.ExpressUrls.Commands
{
  [Serializable]
  public class AddExpressUrlsCommand : Command
  {
    public AddExpressUrlsCommand()
    {
    }

    public override void Execute(CommandContext context)
    {
      if ((int)context.Items.Length == 1)
      {
        string uri = UIUtil.GetUri("control:xmlExpressUrlApp");
        string str = context.Items[0].ID.ToString();
        string str1 = string.Format("{0}&id={1}", uri, str);
        Context.ClientPage.ClientResponse.Broadcast(Context.ClientPage.ClientResponse.ShowModalDialog(str1), "Shell");
      }
    }
  }
}