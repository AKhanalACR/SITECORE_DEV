using ACR.Library;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACRMicroSites.controls.Radpac
{
  public partial class PageTitle : System.Web.UI.UserControl
  {

    public override void RenderControl(HtmlTextWriter output)
    {
      Item currentItem = Sitecore.Context.Item;
      string titleSuffix = AcrGlobals.RADPAC_SITE_TITLE;
      try
      {
        IMeta metaItem = ItemInterfaceFactory.GetItem<IMeta>(currentItem);
        SiteConfigurationItem globalConfigItem = ItemReference.Radpac_Global_SiteConfigurationSettings.InnerItem;

        if (SitecoreUtils.IsValid(PageSettingsItem.TemplateId, currentItem) &&
            ((PageSettingsItem)currentItem).SuppressPageTitleSuffix.Checked)
        {
          titleSuffix = "";
        }
        else
        {
          if (globalConfigItem != null)
          {
            if (!String.IsNullOrEmpty(globalConfigItem.PageTitleSuffix.Text))
              titleSuffix = globalConfigItem.PageTitleSuffix.Text;
          }

        }

        output.RenderBeginTag(HtmlTextWriterTag.Title);
        if (!String.IsNullOrEmpty(titleSuffix)
            && !metaItem.MetaTitle.Equals(titleSuffix)
            && (globalConfigItem != null && !metaItem.MetaTitle.Equals(globalConfigItem.SiteName.Text.Trim()))
            )
          output.Write(metaItem.MetaTitle + " - " + titleSuffix);
        else
          output.Write(metaItem.MetaTitle);

        output.RenderEndTag();
      }
      catch (Exception ex)
      {
        Sitecore.Diagnostics.Log.Error("Context item may not implement IMeta interface. Context item name: " + currentItem.Name,ex,this);

        output.RenderBeginTag(HtmlTextWriterTag.Title);
        output.Write(titleSuffix);
        output.RenderEndTag();
      }
      base.RenderControl(output);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    
    }
  }
}