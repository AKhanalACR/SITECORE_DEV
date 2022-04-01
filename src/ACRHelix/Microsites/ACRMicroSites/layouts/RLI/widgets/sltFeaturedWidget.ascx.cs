using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.controls.RLI;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;
using ACR.Library.RLI.Widgets;
using ACR.Library.Utils;

namespace ACR.layouts.RLI.widgets
{
    public partial class sltFeaturedWidget : RLIWidgetControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get our current item as a Featured item
            FeaturedItem widgetItem = WidgetItem;

            if (widgetItem == null || widgetItem.ContentItem.Item == null)
            {
                Visible = false;
                return;
            }

            IFeatured featuredContentItem = ItemInterfaceFactory.GetItem<IFeatured>(widgetItem.ContentItem.Item);

            if (featuredContentItem == null)
            {
                Visible = false;
                return;
            }

            ltlTitle.Text = (widgetItem.Title.Raw.Trim() != String.Empty) ? widgetItem.Title.Rendered : featuredContentItem.FeaturedTitle;

            hlLearnMore.Text = (widgetItem.LinkText.Raw.Trim() != String.Empty) ? widgetItem.LinkText.Rendered : "Learn More >>";
            hlLearnMore.NavigateUrl = featuredContentItem.FeaturedUrl;


            if (widgetItem.Image != null && widgetItem.Image.MediaItem != null)
            {
                imgFeatured.Initialize(widgetItem.Image.MediaItem, 202, 202);
            }
            else
            {
                imgFeatured.Visible = false;
            }
        }
    }
}