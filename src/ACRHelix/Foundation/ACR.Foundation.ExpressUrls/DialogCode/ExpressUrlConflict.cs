using Sitecore;
using Sitecore.Configuration;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Web;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Pages;
using Sitecore.Web.UI.Sheer;
using System;

namespace ACR.Foundation.ExpressUrls
{
  [Serializable]
  internal class ExpressUrlConflictCodeBeside : DialogForm
  {
    protected Literal ConflictedItem;

    private string conflictItemId;

    public ExpressUrlConflictCodeBeside()
    {
    }

    protected string GetConflictingItemId()
    {
      string queryString = WebUtil.GetQueryString("conflictItemId");
      if (string.IsNullOrEmpty(queryString))
      {
        return string.Empty;
      }
      return queryString;
    }

    private string GetItemText(string itemGuid)
    {
      Item item = Factory.GetDatabase("master").GetItem(ID.Parse(itemGuid));
      if (item != null)
      {
        return string.Concat(item.DisplayName, " - ", item.Paths.ContentPath);
      }
      return itemGuid;
    }

    protected override void OnCancel(object sender, EventArgs args)
    {
      Context.ClientPage.ClientResponse.SetDialogValue("no");
      base.OnCancel(sender, args);
    }

    protected override void OnLoad(EventArgs args)
    {
      base.OnLoad(args);
      this.conflictItemId = this.GetConflictingItemId();
      if (!Context.ClientPage.IsEvent && !string.IsNullOrEmpty(this.conflictItemId))
      {
        this.ConflictedItem.Text=this.GetItemText(this.conflictItemId);
      }
    }

    protected override void OnOK(object sender, EventArgs args)
    {
      Context.ClientPage.ClientResponse.SetDialogValue("yes");
      base.OnOK(sender, args);
    }
  }

}