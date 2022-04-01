using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.Reference;
using ACR.Library.Utils;
using Sitecore.Data.Items;

namespace ACR.layouts.ImageWisely
{
    public partial class sltHome : System.Web.UI.UserControl
    {
			protected void Page_Load(object sender, EventArgs e)
        {
            if(Sitecore.Context.Item.TemplateID.ToString() != HomePageItem.TemplateId)
                return;

				HomePageItem homeItem = ItemReference.ImageWisely.InnerItem;

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
            
          //Introduction
					if (!string.IsNullOrEmpty(homeItem.IntroductoryTitle.Raw) && !string.IsNullOrEmpty(homeItem.IntroductoryText.Raw))
					{
						phIntroduction.Visible = true;
						litIntroTitle.Text = homeItem.IntroductoryTitle.Rendered;
						litIntroText.Text = homeItem.IntroductoryText.Rendered;
					}

            //Callout
			    if (homeItem.IncludeCallout.Checked)
			    {
			        iwCallout.Visible = true;
			    }

        	//News
					if (!string.IsNullOrEmpty(homeItem.NewsTitle.Raw) && !string.IsNullOrEmpty(homeItem.NewsItems.Raw))
					{
						phNews.Visible = true;
						IEnumerable<IListItem> listItems = ItemInterfaceFactory.GetItems<IListItem>(homeItem.NewsItems.ListItems);
						rptNews.DataSource = listItems;
						rptNews.DataBind();
						Literal litNewsTitle = (Literal)rptNews.Controls[0].Controls[0].FindControl("litNewsTitle");
						litNewsTitle.Text = homeItem.NewsTitle.Rendered;
					}
        	

					//Top Reads
					if (!string.IsNullOrEmpty(homeItem.TopReadsTitle.Raw) && !string.IsNullOrEmpty(homeItem.TopReadsText.Raw))
					{
						phTopReads.Visible = true;
						litTopReadsTitle.Text = homeItem.TopReadsTitle.Rendered;
						litTopReadsText.Text = homeItem.TopReadsText.Rendered;
					}
        	

					//Commitment
					if (!string.IsNullOrEmpty(homeItem.CommitmentTitle.Raw) && !string.IsNullOrEmpty(homeItem.CommitmentText.Raw))
					{
						phCommitment.Visible = true;
						litCommitmentTitle.Text = homeItem.CommitmentTitle.Rendered;
						litCommitmentText.Text = homeItem.CommitmentText.Rendered;
					}
        	

					//Additional
					if (!string.IsNullOrEmpty(homeItem.AdditionalTitle.Raw) && !string.IsNullOrEmpty(homeItem.AdditionalText.Raw))
					{
						phAdditional.Visible = true;
						litAdditionalTitle.Text = homeItem.AdditionalTitle.Rendered;
						litAdditionalText.Text = homeItem.AdditionalText.Rendered;
					}
        	

            //Imaging Professionals
						if (ItemReference.IW_ImagingProfessionals_Landing.InnerItem != null)
            {
							Item imgProfItem = ItemReference.IW_ImagingProfessionals_Landing.InnerItem;
                ltlImgProf.Text = ((PageSettingsItem)imgProfItem).PageTitle.Text.ToUpper();
                IEnumerable<Item> listPageItems = imgProfItem.Axes.GetDescendants().Where(i => i.TemplateID.ToString() == ImagingProfessionalsListPageItem.TemplateId).Select(i => i);

                if (listPageItems.Count() > 0)
                {
                    rptImagingProf.DataSource = listPageItems;
                    rptImagingProf.DataBind();
                }
            }

            //Journal
            imgJournal.Initialize(homeItem.RSNAJournalCover.MediaItem,140,102);
            
            if (homeItem.RSNAJournalName != null &&
                homeItem.RSNAJournalName.Text != null &&
                homeItem.RSNAJournalLink != null &&
                homeItem.RSNAJournalLink.Url != null)
            {
                lnkJournalLink.Text = homeItem.RSNAJournalName.Text;
                lnkJournalLink.NavigateUrl = homeItem.RSNAJournalLink.Url;
                lnkJournalLink.Target = homeItem.RSNAJournalLink.Field.Target;
            }

            if (homeItem.RSNAJournalText != null &&
                homeItem.RSNAJournalText.Text != null)
            {
                ltlJournalText.Text = homeItem.RSNAJournalText.Text;                
            }
           
        }

				protected void rptNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
				{
					if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
					{
						HyperLink hlNewsRead = (HyperLink) e.Item.FindControl("hlNewsRead");
						Literal litNewsItemTitle = (Literal) e.Item.FindControl("litNewsItemTitle");
						Literal litNewsItemContent = (Literal) e.Item.FindControl("litNewsItemContent");

						IListItem newsItem = (IListItem)e.Item.DataItem;
						
						if (newsItem == null)
						{
							return;
						}

						litNewsItemTitle.Text = newsItem.LiTitle;
						litNewsItemContent.Text = newsItem.LiDescription;
						hlNewsRead.NavigateUrl = newsItem.LiUrl;
						hlNewsRead.Text = "&raquo; Read article";
					}
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