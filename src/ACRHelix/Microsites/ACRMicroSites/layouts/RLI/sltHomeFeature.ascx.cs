using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.controls.Common;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.RLI.Components;
using ACR.Library.RLI.Interfaces;
using ACR.Library.RLI.Pages;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.RLI
{
    public partial class sltHomeFeature : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SitecoreUtils.IsValid(RLIHomepageItem.TemplateId, Sitecore.Context.Item))
            {
                return;
            }
            RLIHomepageItem homeItem = Sitecore.Context.Item;

            IList<HomeFeaturedItem> features = homeItem.Features.Take(2).ToList();
            rptFeatures.DataSource = features;
            rptFeatures.DataBind();
        }

        protected void rptFeatures_DataBound(object sender, RepeaterItemEventArgs e)
        {
            HomeFeaturedItem feature = e.Item.DataItem as HomeFeaturedItem;
            if (feature == null)
            {
                return;
            }

            if (feature.ContentItem.Item == null)
            {
                return;
            }

            IFeatured featuredContentItem = ItemInterfaceFactory.GetItem<IFeatured>(feature.ContentItem.Item);

            if (featuredContentItem == null)
            {
                return;
            }

            var ltlHeader = (Literal)e.Item.FindControl("ltlHeader");
            var ltlSubheader = (Literal)e.Item.FindControl("ltlSubheader");
            var ltlBody = (Literal)e.Item.FindControl("ltlBody");
            var hlLearnMore = (HyperLink)e.Item.FindControl("hlLearnMore");
            var imgFeatured = (SitecoreImage)e.Item.FindControl("imgFeatured");


            ltlHeader.Text = (feature.Title.Raw.Trim() != String.Empty) ? feature.Title.Rendered : featuredContentItem.FeaturedTitle;

            string subheader = (feature.Subheader.Raw.Trim() != String.Empty)
                                   ? feature.Subheader.Rendered
                                   : featuredContentItem.FeaturedSubheader;
            if (!String.IsNullOrEmpty(subheader))
                ltlSubheader.Text = "<h3>" + subheader + "</h3>";

            ltlBody.Text = (feature.Body.Raw.Trim() != String.Empty) ? feature.Body.Rendered : featuredContentItem.FeaturedDescription;

            hlLearnMore.Text = (feature.LinkText.Raw.Trim() != String.Empty) ? feature.LinkText.Rendered : "Learn More >>";
            hlLearnMore.NavigateUrl = featuredContentItem.FeaturedUrl;
            

            if (feature.Image != null && feature.Image.MediaItem != null)
            {
                imgFeatured.Initialize(feature.Image.MediaItem, 122, 310);
            }
            else
            {
                imgFeatured.Visible = false;
            }
        }
        
    }
}