using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Common;
using ACR.Library.Common.Interfaces;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Utils;
using System.Configuration;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.SSO.Utils;

namespace ACR.controls.Radpac
{
    public partial class BreadcrumbUtilityLinks : System.Web.UI.UserControl
    {
        private int totalCrumbs = 0;
        private bool UserLoggedOut = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                EnableLogoutBtn();
                return;
            }
            EnableLogoutBtn();
            StandardBreadcrumb crumb = new StandardBreadcrumb(Sitecore.Context.Item);

            if (crumb.BreadcrumbLinks.Count == 0)
            {
                rptBreadcrumb.Visible = false;
            }
            else
            {
                totalCrumbs = crumb.BreadcrumbLinks.Count;
                rptBreadcrumb.DataSource = crumb.BreadcrumbLinks;
                rptBreadcrumb.DataBind();
            }

            if (SitecoreUtils.IsValid(GeneralPageItem.TemplateId, Sitecore.Context.Item))
            {
                GeneralPageItem generalPageItem = Sitecore.Context.Item;
                string pdfDownloadUrl = generalPageItem.AssociatedPdfUrl;
                if (pdfDownloadUrl != String.Empty)
                    ltlPdfDownload.Text =
                        String.Format(
                            "<span class=\"ic_icon ic_pdf\">&nbsp;</span><a href=\"{0}\" target=\"_blank\">Download PDF</a>",
                            pdfDownloadUrl);
            }
        }

        private void EnableLogoutBtn()
        {
            bool isUserAuthorized = false;
            // Redirect the user if he's authenticated already        
            if (UserManager.CurrentUserContext.CurrentCustomerToken != null && UserManager.CurrentUserContext.CurrentCustomerToken != "")
            {
                if (!UserManager.CurrentUserContext.CurrentUser.IsInternationalUser)
                    isUserAuthorized = true;
            }
            else
            {
                isUserAuthorized = AcrSsoUtil.IsAuthorized(HttpContext.Current, Sitecore.Context.Item);
            }
            if (isUserAuthorized)
            {        
               // if(!UserLoggedOut )
                  lnkBtnLogout.Visible = true;
            }
        }

        protected void rptBreadcrumb_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl liCrumb = (HtmlGenericControl)e.Item.FindControl("liCrumb");
                Literal litCrumb = (Literal)e.Item.FindControl("litCrumb");
                IPageItem crumbLink = (IPageItem)e.Item.DataItem;

                //If this is the last link, don't linkify it
                if (e.Item.ItemIndex == totalCrumbs - 1)
                {
                    litCrumb.Text = LinkUtils.GetBreadcrumbFinalHtml(crumbLink.NavTitle);
                }
                else
                {
                    litCrumb.Text = LinkUtils.GetBreadcrumbLinkHtml(crumbLink.NavUrl, crumbLink.NavTitle);
                }
            }
        }
        protected void lnkBtnLogout_Click(object sender, EventArgs e)
        {
            string rawUrl = Sitecore.Context.RawUrl;
            string url = "http://" + HttpContext.Current.Request.Url.Host + "/";
            if (Request.RawUrl != null)
                //if (Request.RawUrl.ToString().ToUpper().Contains("RADPAC"))
                //    url += "/Radpac/";
            url += "Login Page?Logout=true";
            lnkBtnLogout.Visible = false;
            UserManager.CurrentUserContext.Logout();
            
            //UserLoggedOut = true;           
            Response.Redirect   (url );

        }
        
    }
}