using ACR.Library;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACRMicroSites.controls.Common
{
  public partial class MetaHeaders : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public override void RenderControl(HtmlTextWriter output)
    {
      if (Sitecore.Context.Item == null)
      {
        return;
      }

      Item currentItem = Sitecore.Context.Item;

      output.WriteLine();
      //The following is for the Favicon 
      if (SiteUtils.GetSiteByContext() == SiteNames.ImageWisely)
      {
        output.AddAttribute(HtmlTextWriterAttribute.Rel, "shortcut icon");
        output.AddAttribute(HtmlTextWriterAttribute.Href, "/images/ImageWisely/favicon.ico");
        output.RenderBeginTag(HtmlTextWriterTag.Link);
        output.RenderEndTag();
      }
      else if (SiteUtils.GetSiteByContext() == SiteNames.Airp)
      {
        output.AddAttribute(HtmlTextWriterAttribute.Rel, "shortcut icon");
        output.AddAttribute(HtmlTextWriterAttribute.Href, "/images/AIRP/favicon.ico");
        output.RenderBeginTag(HtmlTextWriterTag.Link);
        output.RenderEndTag();
      }

      try
      {
        IMeta metaItem = ItemInterfaceFactory.GetItem<IMeta>(currentItem);

        //Write Meta tags
        DisplayMetaTitle(metaItem, output);
        DisplayMetaDescription(metaItem, output);
        DisplayMetaKeywords(metaItem, output);
        DisplayMetaDate(metaItem, output);
        DisplayNoFollowTag(output);
        DisplayMetaVerify(metaItem, output);
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Context item may not implement IMeta interface. Context item name: " + currentItem.Name, ex, this);
        //Logger.Info("Context item may not implement IMeta interface. Context item name: " + currentItem.Name);
      }

      base.RenderControl(output);
    }

    private void DisplayMetaTitle(IMeta metaItem, HtmlTextWriter output)
    {
      if (!String.IsNullOrEmpty(metaItem.MetaTitle))
        DisplayMetaTag("metaTitle", "title", metaItem.MetaTitle, output);
    }


    private void DisplayMetaDescription(IMeta metaItem, HtmlTextWriter output)
    {
      if (!String.IsNullOrEmpty(metaItem.MetaDescription))
        DisplayMetaTag("metaDescription", "description", metaItem.MetaDescription, output);
    }


    private void DisplayMetaDate(IMeta metaItem, HtmlTextWriter output)
    {
      if (!String.IsNullOrEmpty(metaItem.MetaDate))
        DisplayMetaTag("metaDate", "date", metaItem.MetaDate, output);
    }

    private void DisplayMetaKeywords(IMeta metaItem, HtmlTextWriter output)
    {
      if (!String.IsNullOrEmpty(metaItem.MetaKeywords))
        DisplayMetaTag("metaKeywords", "keywords", metaItem.MetaKeywords, output);
    }

    private void DisplayNoFollowTag(HtmlTextWriter output)
    {
      //if ((HttpContext.Current.Request.QueryString[AcrGlobals.EmailFriendReferrerValue] != null && HttpContext.Current.Request.QueryString[AcrGlobals.EmailFriendReferrerValue] == "1")
      //{
      //    _displayMetaTag("metaRobots", "ROBOTS", "NOINDEX, NOFOLLOW", output);
      //}
    }


    private void DisplayMetaVerify(IMeta metaItem, HtmlTextWriter output)
    {
      if (!String.IsNullOrEmpty(metaItem.MetaVerify))
        DisplayMetaTag(null, "verify-v1", metaItem.MetaVerify, output);
    }

    private void DisplayMetaTag(string id, string name, string content, HtmlTextWriter output)
    {
      //<meta id="metaTitle" name="title" content="Kaiser Global Health" />
      output.WriteLine();

      if (!String.IsNullOrEmpty(id))
        output.AddAttribute(HtmlTextWriterAttribute.Id, id);

      output.AddAttribute(HtmlTextWriterAttribute.Name, name);
      output.AddAttribute(HtmlTextWriterAttribute.Content, content);
      output.RenderBeginTag(HtmlTextWriterTag.Meta);
      output.RenderEndTag();
    }

  }
}