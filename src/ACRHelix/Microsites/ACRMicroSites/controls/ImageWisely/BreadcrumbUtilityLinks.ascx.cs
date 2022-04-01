using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Common;
using ACR.Library.Common.Interfaces;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.Utils;

namespace ACR.controls.ImageWisely
{
    public partial class BreadcrumbUtilityLinks : System.Web.UI.UserControl
    {
        private int totalCrumbs = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

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
    }
}