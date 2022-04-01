using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Components;
using ACR.Library.Reference;
using ACR.Library.Utils;

namespace ACR.layouts.ImageWisely
{
    public partial class sltMainContent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SitecoreUtils.IsValid(PageSettingsItem.TemplateId, Sitecore.Context.Item))
            {
                ltlPageTitle.Text = ((PageSettingsItem) Sitecore.Context.Item).PageTitle.Rendered;
            }

            if (SitecoreUtils.IsValid(ContentPageItem.TemplateId, Sitecore.Context.Item))
            {
                ContentPageItem contentPageItem = Sitecore.Context.Item;

                //Optional Image
                if (contentPageItem.OptionalFloatedImage.MediaItem != null && !String.IsNullOrEmpty(contentPageItem.OptionalFloatedImage.MediaItem.MediaPath))
                    imgGeneral.Initialize(contentPageItem.OptionalFloatedImage.MediaItem);
                else
                    imgGeneral.Visible = false;

                //Body Text
                ltlGeneral.Text = (String.IsNullOrEmpty(contentPageItem.Optionalembeddedvideo.Raw))?
                    contentPageItem.BodyText.Rendered:
                    contentPageItem.BodyText.Rendered + "<p>" + contentPageItem.Optionalembeddedvideo.Raw  + "</p>";

                //Patient Imaging Card
                if (contentPageItem.DisplayPatientImagingCard.Checked)
                {
									if (ItemReference.IW_Global_PatientImagingHistoryCard.InnerItem != null)
                    {
                        PatientImagingHistoryCardItem cardItem =
														ItemReference.IW_Global_PatientImagingHistoryCard.InnerItem;
                        imgCard.Initialize(cardItem.Image.MediaItem);
                        hlCard1.NavigateUrl = cardItem.CardLink.Url;
                        hlCard2.NavigateUrl = cardItem.CardLink.Url;
                        hlCard3.NavigateUrl = cardItem.CardLink.Url;
                        ltlCardTitle.Text = cardItem.Title.Rendered;
                        ltlWalletTitle.Text = cardItem.WalletTitle.Rendered;
                        hlWalletCard1.NavigateUrl = cardItem.WalletLink.Url;
                        hlWalletCard2.NavigateUrl = cardItem.WalletLink.Url;
                        ltlCardText.Text = cardItem.Description.Rendered;
                        pnlImgCard.Visible = true;
                    }
                }
            }
            else
            {
                imgGeneral.Visible = false;
            }

        }
    }
}