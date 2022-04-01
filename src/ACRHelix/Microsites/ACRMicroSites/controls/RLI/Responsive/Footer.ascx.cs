using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Components;
using ACR.Library.RLI.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace ACR.controls.RLI.Responsive
{
  public partial class Footer : System.Web.UI.UserControl
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      RLIHomepageItem homeItem = ItemReference.RLI.InnerItem;
      RLISiteSettingsItem settingsItem = ItemReference.RLI_Settings.InnerItem;
      if (homeItem == null || settingsItem == null)
      {
        return;
      }

      hlFacebook1.NavigateUrl = hlFacebook.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.FacebookURL.Text);
      hlTwitter1.NavigateUrl = hlTwitter.NavigateUrl = LinkUtils.GetExternalUrl(settingsItem.TwitterURL.Text);

      rptFooterLinkColumns.DataSource =
        homeItem.InnerItem.Children.Select(item => (NavigationBaseItem)item).Where(
          item => item.IncludeinBottomNavigation.Checked);
      rptFooterLinkColumns.DataBind();

      litCopyright.Text = settingsItem.CopyrightText.Rendered;

      rptButtons.DataSource = settingsItem.FooterButtons.ListItems;
      rptButtons.DataBind();
    }

    protected void rptFooterLinkColumns_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      NavigationBaseItem item = (NavigationBaseItem)e.Item.DataItem;
      var hypHeaderLink = (HyperLink)e.Item.FindControl("hypHeaderLink");
      hypHeaderLink.NavigateUrl = LinkUtils.GetItemUrl(item);
      hypHeaderLink.Text = TitleFactory.GetRLINavTitle(item);

      var rptFooterLinks = (Repeater)e.Item.FindControl("rptFooterLinks");
      rptFooterLinks.DataSource =
                item.InnerItem.Children.Select(subNavItem => (NavigationBaseItem)subNavItem).Where(
          subNavItem => subNavItem.IncludeinBottomNavigation.Checked);
      rptFooterLinks.DataBind();
    }

    protected void rptFooterLink_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      NavigationBaseItem navBaseItem = (NavigationBaseItem)e.Item.DataItem;

      if (!SitecoreUtils.IsValid(PageBaseItem.TemplateId, navBaseItem.InnerItem))
      {
        return;
      }

      PageBaseItem item = navBaseItem.InnerItem;
      var hypLink = (HyperLink)e.Item.FindControl("hypLink");
      hypLink.NavigateUrl = LinkUtils.GetItemUrl(item);
      hypLink.Text = TitleFactory.GetRLINavTitle(item);
    }

    protected void rptButtons_OnItemDataBound(object sender, RepeaterItemEventArgs e)
    {
      ButtonItem button = new ButtonItem((Item)e.Item.DataItem);
      HyperLink hlButton = (HyperLink)e.Item.FindControl("hlButton");
      Image imgButtonIcon = (Image)e.Item.FindControl("imgButtonIcon");
      Literal litButtonTitle = (Literal)e.Item.FindControl("litButtonTitle");

      hlButton.NavigateUrl = LinkUtils.GetLinkFieldUrl(button.Link.Field);
      hlButton.Target = button.Link.Field.Target;
      litButtonTitle.Text = button.Title.Text;
      if (button.Icon == null || button.Icon.MediaItem == null)
      {
        imgButtonIcon.Visible = false;
        return;
      }
      imgButtonIcon.ImageUrl = MediaManager.GetMediaUrl(button.Icon.MediaItem);
    }
  }
}