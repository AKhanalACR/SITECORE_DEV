using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Reference;
using ACR.Library.Utils;
using System.Configuration;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.SSO.Utils;

namespace ACR.layouts.Radpac
{
    public partial class sltMainContent : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (SitecoreUtils.IsValid(PageSettingsItem.TemplateId, Sitecore.Context.Item))
            {
                this.ltlPageTitle.Text = ((PageSettingsItem)Sitecore.Context.Item).PageTitle.Rendered;
            }

            if (SitecoreUtils.IsValid(ContentPageItem.TemplateId, Sitecore.Context.Item))
            {
                ContentPageItem contentPageItem = Sitecore.Context.Item;
                CheckLogin();
                //Optional Image
                if (contentPageItem.OptionalFloatedImage.MediaItem != null && !String.IsNullOrEmpty(contentPageItem.OptionalFloatedImage.MediaItem.MediaPath))
                    imgGeneral.Initialize(contentPageItem.OptionalFloatedImage.MediaItem);
                else
                    imgGeneral.Visible = false;

                //Body Text
                ltlGeneral.Text = (String.IsNullOrEmpty(contentPageItem.Optionalembeddedvideo.Raw)) ?
                    contentPageItem.BodyText.Rendered :
                    contentPageItem.BodyText.Rendered + "<p>" + contentPageItem.Optionalembeddedvideo.Raw + "</p>";

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

        private void CheckForLogin()
        {
            PageSettingsItem psItem = Sitecore.Context.Item;
            string rawUrl = Sitecore.Context.RawUrl;

            #region Check for Login
            bool isRequiredLogin = psItem.RequiresUserLogin;
            if (isRequiredLogin)
            {
                bool isUserAuthorized=false;
                // Redirect the user if he's not authenticated already 
                if (UserManager.CurrentUserContext.CurrentCustomerToken !=null && UserManager.CurrentUserContext.CurrentCustomerToken !="")
                {
                    if(!UserManager .CurrentUserContext .CurrentUser .IsInternationalUser )
                        isUserAuthorized = true;
                }
                else
                {
                    isUserAuthorized = AcrSsoUtil.IsAuthorized(HttpContext.Current, Sitecore.Context.Item);
                }
                if (!isUserAuthorized)
                {
                        string url = "http://" + HttpContext.Current.Request.Url.Host + "/";
                        if (Request.RawUrl != null)
                           // if (Request.RawUrl.ToString().ToUpper ().Contains("RADPAC"))
                               // url += "/Radpac/";
                        url += "Login Page?RedirectPage=";
                       
                        Response.Redirect(url + rawUrl);
                 }
                 
            }
            #endregion
        }

        private void CheckLogin()
        {
            PageSettingsItem psItem = Sitecore.Context.Item;
            string rawUrl = Sitecore.Context.RawUrl;

            #region Check for Login
            bool isRequiredLogin = psItem.RequiresUserLogin;
            if (isRequiredLogin)
            {
                bool isUserAuthorized = false;
                // Redirect the user if he's not authenticated already 
                if (UserManager.CurrentUserContext.CurrentCustomerToken != null && UserManager.CurrentUserContext.CurrentCustomerToken != "")
                {
                    if (!UserManager.CurrentUserContext.CurrentUser.IsInternationalUser)
                        isUserAuthorized = true;
                }
                else
                {
                    isUserAuthorized = AcrSsoUtil.IsAuthorized(HttpContext.Current, Sitecore.Context.Item);
                }
                if (!isUserAuthorized)
                {
                    string url = "http://" + HttpContext.Current.Request.Url.Host + "/";
                    if (Request.RawUrl != null)
                        //if (Request.RawUrl.ToString().ToUpper().Contains("RADPAC"))
                           // url += "/Radpac/";
                    url += "Login Page?RedirectPage=";
                    UserManager.CurrentUserContext.LoginWithPrompt( url);
                    //Response.Redirect(url + rawUrl);
                }

            }
            #endregion
        }
    }
}