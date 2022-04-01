using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Common.Interfaces;
using Common.Logging;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using System.Web;
using System.Configuration;
using ACR.Foundation.SSO.Users;
using ACR.controls.Common;
using ACR.Foundation.SSO.Utils;

namespace ACR.layouts.Radpac
{
    public partial class sltList : System.Web.UI.UserControl
    {
        private IEnumerable<IListItem> _allListItems;
        private IEnumerable<String> _allHeaderTitles;
        private bool _showBookmarks;
        private StringBuilder _bookmarks;
        private int _headerCount;

        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(sltList));
                return _logger;
            }
        }
        protected void Page_Init(object sender, EventArgs e)
        {

            CheckLogin();
        }

       
        protected void Page_Load(object sender, EventArgs e)
        {
            _bookmarks = new StringBuilder();

            try
            {
                CheckForLogin();
                 IListPage listPageItem = ItemInterfaceFactory.GetItem<IListPage>(Sitecore.Context.Item);
                
                _allListItems = listPageItem.ListItems;
                _allHeaderTitles = listPageItem.HeaderTitles;
                _showBookmarks = (listPageItem.DisplayHeaderBookmarks && _allHeaderTitles.Count() > 1);
            }
            catch (Exception ex)
            {
                Logger.Error("sltList.apsx.cs: The context item may not implement the IListPage interface.", ex);
            }

            if (_allHeaderTitles != null)
            {
                _headerCount = 0;
                rptHeadings.DataSource = _allHeaderTitles;
                rptHeadings.DataBind();
            }

            if (_showBookmarks && _bookmarks.Length > 0)
            {
                pnlTopicBookmarks.Visible = true;
                ltlBookmarks.Text = _bookmarks.ToString();
            }
        }


        protected void RptHeadingsItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                String listHeaderTitle = (String)e.Item.DataItem;
                if (listHeaderTitle == null) return;

                Literal ltlHeadingTitle = (Literal)e.Item.FindControl("ltlHeadingTitle");
                if (_showBookmarks)
                {
                    ltlHeadingTitle.Text = String.Format("<a name=\"Topic{0}\"></a>{1}", _headerCount, listHeaderTitle);
                    _bookmarks.AppendFormat("<a href=\"#Topic{0}\">&raquo; {1}</a>", _headerCount, listHeaderTitle);
                }
                else
                {
                    ltlHeadingTitle.Text = listHeaderTitle;
                }

                if (_allListItems != null && _allListItems.Count() > 0)
                {
                    Repeater rptList = (Repeater)e.Item.FindControl("rptList");
                    rptList.DataSource = _allListItems.Where(i => i.LiTopic == listHeaderTitle);
                    rptList.DataBind();
                }
                _headerCount++;

            }
        }

        protected void RptListItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                IListItem listItem = (IListItem)e.Item.DataItem;
                if (listItem == null) return;

                HyperLink hlListItem = (HyperLink)e.Item.FindControl("hlListItem");
                Literal ltlDescription = (Literal)e.Item.FindControl("ltlDescription");
                Literal ltlBullet = (Literal)e.Item.FindControl("ltlBullet");
                SitecoreImage lstImage = (SitecoreImage)e.Item.FindControl("lstImage");

                if (listItem.LiImage != null)
                    lstImage.Initialize(listItem.LiImage, 800, 500);
                else
                    lstImage.Visible = false;
               
                if(listItem .LiIsPdf)
                if (String.IsNullOrEmpty(listItem.LiTitle) || String.IsNullOrEmpty(listItem.LiUrl)) return;

               

                ltlBullet.Text = "&raquo;";
                hlListItem.Text =  listItem.LiTitle;
                hlListItem.NavigateUrl = listItem.LiUrl;
                hlListItem.Target = listItem.LiLinkTarget;
                ltlDescription.Text = listItem.LiDescription;

                if (listItem.LiIsPdf)
                if(!String.IsNullOrEmpty(listItem.LiAssociatedPdfUrl))
                {
                    Literal ltlIcon = (Literal)e.Item.FindControl("ltlIcon");
                    ltlIcon.Text = String.Format("<p class=\"pdfico\"><a href=\"{0}\" target=\"_blank\">Download PDF</a></p>",
                        listItem.LiIsPdf ? listItem.LiUrl : listItem.LiAssociatedPdfUrl);
                }

            }
        }

        #region helper methods

        private void CheckForLogin()
        {
            PageSettingsItem psItem = Sitecore.Context.Item;
            string rawUrl = Sitecore.Context.RawUrl;

            #region Check for Login
            bool isRequiredLogin = psItem.RequiresUserLogin;
            if (isRequiredLogin)
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
                if (!isUserAuthorized)
                {
                    string url = "http://" + HttpContext.Current.Request.Url.Host;
                    if (Request.RawUrl != null)
                       // if (Request.RawUrl.ToString().ToUpper().Contains("RADPAC"))
                           // url += "/RADPAC/";
                    url += "Login Page?RedirectPage=";
                    Response.Redirect(url + rawUrl);
                }

                //Response.Redirect(rawUrl, true);  
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
                if (!isUserAuthorized)
                {
                    string url = "http://" + HttpContext.Current.Request.Url.Host + "/";
                    if (Request.RawUrl != null)
                        //if (Request.RawUrl.ToString().ToUpper().Contains("RADPAC"))
                           // url += "/Radpac/";
                    url += "Login Page?RedirectPage=" ;
                    UserManager.CurrentUserContext.LoginWithPrompt( url);
                    //Response.Redirect(url + rawUrl);
                }

                //Response.Redirect(rawUrl, true);  
            }
            #endregion
        }
        #endregion
    }
}