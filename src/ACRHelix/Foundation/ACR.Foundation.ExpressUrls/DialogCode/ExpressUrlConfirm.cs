using Sitecore;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;

namespace ACR.Foundation.ExpressUrls
{
  [Serializable]
  internal class ExpressUrlConfirmCodeBeside : DialogForm
  {
    protected Literal SuggestedUrl;

    private string suggestedExpressUrl;

    public ExpressUrlConfirmCodeBeside()
    {
    }

    protected string GetSuggestedExpressUrl()
    {
      string queryString = WebUtil.GetQueryString("suggestedExpressUrl");
      if (string.IsNullOrEmpty(queryString))
      {
        return string.Empty;
      }
      return queryString;
    }

    protected override void OnCancel(object sender, EventArgs args)
    {
      Context.ClientPage.ClientResponse.SetDialogValue("no");
      base.OnCancel(sender, args);
    }

    protected override void OnLoad(EventArgs args)
    {
      base.OnLoad(args);
      this.suggestedExpressUrl = this.GetSuggestedExpressUrl();
      if (!Context.ClientPage.IsEvent && !string.IsNullOrEmpty(this.suggestedExpressUrl))
      {
        this.SuggestedUrl.Text=this.suggestedExpressUrl;
      }
    }

    protected override void OnOK(object sender, EventArgs args)
    {
      Context.ClientPage.ClientResponse.SetDialogValue("yes");
      base.OnOK(sender, args);
    }
  }
}