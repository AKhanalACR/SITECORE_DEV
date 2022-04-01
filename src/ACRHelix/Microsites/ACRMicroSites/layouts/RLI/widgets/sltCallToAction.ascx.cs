using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.controls.RLI;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.RLI.Components;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;
using ACR.Library.RLI.Widgets;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.RLI.widgets
{
    public partial class sltCallToAction : RLIWidgetControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get our current item as a Call To Action item
            CallToActionItem ctaItem = WidgetItem;

            if (ctaItem == null)
            {
                Visible = false;
                return;
            }

            ltlHeader.Text = ctaItem.Header.Rendered;
            ltlSubheader.Text = ctaItem.SubheaderText.Rendered;
            ltlBottomText.Text = ctaItem.BottomText.Rendered;

            if (ctaItem.Icon != null && ctaItem.Icon.MediaItem != null)
            {
                imgIcon.Initialize(ctaItem.Icon.MediaItem);
            }
            else
            {
                imgIcon.Visible = false;
            }

            if(ctaItem.Button.Item != null)
            {
                ButtonItem button = ctaItem.Button.Item;
                //Render Button if exists
                string buttonUrl = LinkUtils.GetLinkFieldUrl(button.Link.Field);
                if (buttonUrl != String.Empty)
                {
                    hlButton.NavigateUrl = buttonUrl;
                    hlButton.Target = button.Link.Field.Target;
                    ltlBtnTitle.Text = button.Title.Rendered;
                    if (button.Icon.MediaItem != null)
                    {
                        imgButtonIcon.Initialize(button.Icon.MediaItem, 41, 48);	
            		hlButton.CssClass += " icon";
                    }
                    else
                    {
                        imgButtonIcon.Visible = false;
                    }
                }
                else
                {
                    hlButton.Visible = false;
                }
            }
            else
            {
                hlButton.Visible = false;
            }
            
            
            
            
        }
    }
}