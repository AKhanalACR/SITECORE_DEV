using ACR.Library;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Common.Logging;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACRMicroSites.controls.ImageWisely
{
  public partial class PageTitle : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private static ILog _logger;
    private static ILog Logger
    {
      get
      {
        _logger = _logger ?? LogManager.GetLogger(typeof(PageTitle));
        return _logger;
      }
    }

    #region Overrides of WebControl

    protected override void Render(HtmlTextWriter output)
    {
      Item currentItem = Sitecore.Context.Item;
      string titleSuffix = AcrGlobals.IMAGEWISELY_SITE_TITLE;
      string pageTitle = string.Empty;

      try
      {
        IMeta metaItem = ItemInterfaceFactory.GetItem<IMeta>(currentItem);
        SiteConfigurationItem globalConfigItem = ItemReference.IW_Global_SiteConfigurationSettings.InnerItem;
        PageSettingsItem pageSettingsItem = currentItem;

        if (SitecoreUtils.IsValid(PageSettingsItem.TemplateId, currentItem) && pageSettingsItem.SuppressPageTitleSuffix.Checked)
        {
          titleSuffix = "";
        }
        else
        {
          if (globalConfigItem != null)
          {
            if (!string.IsNullOrEmpty(globalConfigItem.PageTitleSuffix.Text))
            {
              titleSuffix = globalConfigItem.PageTitleSuffix.Text;
            }
          }
        }

        if (metaItem != null)
        {
          pageTitle = metaItem.MetaTitle;
        }
        else if (!string.IsNullOrEmpty(pageSettingsItem.PageTitle.Raw))
        {
          pageTitle = pageSettingsItem.PageTitle.Text;
        }

        output.RenderBeginTag(HtmlTextWriterTag.Title);

        if (!string.IsNullOrEmpty(pageTitle) && !string.IsNullOrEmpty(titleSuffix) && !pageTitle.Equals(titleSuffix) &&
                    (globalConfigItem != null && !pageTitle.Equals(globalConfigItem.SiteName.Text.Trim())))
        {
          output.Write(string.Format("{0} - {1}", pageTitle, titleSuffix));
        }
        else if (!string.IsNullOrEmpty(pageTitle))
        {
          output.Write(pageTitle);
        }
        else
        {
          output.Write(titleSuffix);
        }

        output.RenderEndTag();
      }
      catch (Exception)
      {
        Logger.Info("Context item may not implement IMeta interface. ");

        output.RenderBeginTag(HtmlTextWriterTag.Title);
        output.Write(titleSuffix);
        output.RenderEndTag();
      }
    }

    #endregion
  }
}