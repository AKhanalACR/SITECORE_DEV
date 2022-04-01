using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.RLI.Base;
using ACR.Library.Utils;
using Sitecore.Resources.Media;

namespace ACR.layouts.RLI
{
    public partial class LtRLISubPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }

            if (Sitecore.Context.Item == null)
            {
                return;
            }

						if (!String.IsNullOrEmpty(TitleFactory.GetRLINavTitle(Sitecore.Context.Item)))
						{
							pageTitle.Text = string.Format("{0} - {1}", TitleFactory.GetRLINavTitle(Sitecore.Context.Item), AcrGlobals.RLI_SITE_TITLE);
						}
						else
						{
							pageTitle.Text = AcrGlobals.RLI_SITE_TITLE;
						}

            var widgetPage = ItemInterfaceFactory.GetItem<IWidgetPage>(Sitecore.Context.Item);
            if (widgetPage != null && widgetPage.WidgetItems != null && widgetPage.WidgetItems.Count > 0)
            {
                pnlWrapper.CssClass = " wrapper pageBody subPage widgets cf";
                phWidgets.Visible = true;
            }
            else
            {
                pnlWrapper.CssClass = "wrapper pageBody subPage cf";
            }

            //Set background image
            if (SitecoreUtils.IsValid(BackgroundBaseItem.TemplateId, Sitecore.Context.Item))
            {
                BackgroundBaseItem bkditem = Sitecore.Context.Item;
                if(bkditem.BackgroundImage.MediaItem != null)
                {
                    imgBkd.ImageUrl = MediaManager.GetMediaUrl(bkditem.BackgroundImage.MediaItem);
                }
            }
        }
    }
}