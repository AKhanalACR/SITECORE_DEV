using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.Radpac
{
    public partial class sltHome : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Sitecore.Context.Item.TemplateID.ToString() != HomePageItem.TemplateId)
                return;

            HomePageItem homeItem = Sitecore.Context.Item;


            //Spotlight Item
            if (homeItem.SpotlightImage.MediaItem != null)
            {
                imgSpotlight.Visible = true;
                imgSpotlight.Initialize(homeItem.SpotlightImage.MediaItem, 300, 677);
            }

            //Spotlight Video
            if (!String.IsNullOrEmpty(homeItem.SpotlightVideo.Raw))
            {
                phVideo.Visible = true;
                hlFlowPlayer.NavigateUrl = homeItem.SpotlightVideo.Raw;
            }

            //Intro Text
            ltlIntro.Text = homeItem.IntroductoryText.Rendered;

            //Imaging Professionals
            //if (ItemReference.Radpac_ImagingProfessionals.InnerItem != null)
            //{
            //    Item imgProfItem = ItemReference.Radpac_ImagingProfessionals.InnerItem;
            //    ltlImgProf.Text = ((PageSettingsItem)imgProfItem).PageTitle.Text.ToUpper();
            //    IEnumerable<Item> listPageItems = imgProfItem.Axes.GetDescendants().Where(i => i.TemplateID.ToString() == ImagingProfessionalsListPageItem.TemplateId).Select(i => i);

            //    if (listPageItems.Count() > 0)
            //    {
            //        rptImagingProf.DataSource = listPageItems;
            //        rptImagingProf.DataBind();
            //    }
            //}

            //Journal
            //imgJournal.Initialize(homeItem.RSNAJournalCover.MediaItem, 140, 102);

            //if (homeItem.RSNAJournalName != null &&
            //    homeItem.RSNAJournalName.Text != null &&
            //    homeItem.RSNAJournalLink != null &&
            //    homeItem.RSNAJournalLink.Url != null)
            //{
            //    lnkJournalLink.Text = homeItem.RSNAJournalName.Text;
            //    lnkJournalLink.NavigateUrl = homeItem.RSNAJournalLink.Url;
            //    lnkJournalLink.Target = homeItem.RSNAJournalLink.Field.Target;
            //}

            //if (homeItem.RSNAJournalText != null &&
            //    homeItem.RSNAJournalText.Text != null)
            //{
            //    ltlJournalText.Text = homeItem.RSNAJournalText.Text;
            //}

        }

        protected void rptImagingProf_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Item item = (Item)e.Item.DataItem;
                if (item == null) return;

                HyperLink hlImagingProf = (HyperLink)e.Item.FindControl("hlImagingProf");
                Literal ltlImagingProfText = (Literal)e.Item.FindControl("ltlImagingProfText");

                hlImagingProf.Text = "&raquo; " + ((PageSettingsItem)item).PageTitle.Rendered;
                hlImagingProf.NavigateUrl = CustomItemUtils.GetItemUrl((ImagingProfessionalsListPageItem)item);
                ltlImagingProfText.Text = ((ImagingProfessionalsListPageItem)item).HomePageText.Rendered;
            }
        }
    }
}