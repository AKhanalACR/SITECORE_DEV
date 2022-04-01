using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Radpac.CustomItems.Radpac.Base;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Radpac.CustomItems.Radpac.Pages;
using ACR.Library.Radpac.Utils;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using System.Configuration;
using ACR.Foundation.SSO.Users;
using ACR.Foundation.SSO.Utils;

namespace ACR.controls.Radpac
{
    public partial class MainNav : System.Web.UI.UserControl
    {
        private List<PageSettingsItem> _navItems;
        private IEnumerable<IListItem> _allListItems;
        private IEnumerable<String> _allHeaderTitles;
        private string _alternateUrl = "";
        
        protected bool _isUserAuthorized = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPageItem contentPageItem = Sitecore.Context.Item;

            _navItems = NavUtil.GetMainNavItems(ItemReference.Radpac.InnerItem);
            if (_navItems.Count > 0)
            {
                _isUserAuthorized = IsUserAuthorized();
                rptMainNav.DataSource = _navItems;
                rptMainNav.DataBind();
            }
            else
            {
                rptMainNav.Visible = false;
            }
        }

        protected void rptMainNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlGenericControl liMain = (HtmlGenericControl)e.Item.FindControl("liMain");
                HyperLink hlNavItem = (HyperLink)e.Item.FindControl("hlNavItem");

                HyperLink hlSepItem = (HyperLink)e.Item.FindControl("hlSepItem");

                Repeater rptSubNav = (Repeater)e.Item.FindControl("rptSubNav");

                PageSettingsItem psItem = (PageSettingsItem)e.Item.DataItem;

                //Item ancestor = NavUtil.GetFirstLevelAncestor(Sitecore.Context.Item);
                //if (ancestor != null && ancestor.ID.ToString() == psItem.ID.ToString())
                //{
                //    hlNavItem.CssClass = "selected";
                //}

								IPageItem pageItem = ItemInterfaceFactory.GetItem<IPageItem>(psItem.InnerItem);
                
                hlNavItem.Text = pageItem.NavTitle;
                hlNavItem.NavigateUrl = pageItem.NavUrl;
                //hlSepItem.CssClass = "xp_sepitem";// +(e.Item.ItemIndex + 1);

                //By request the "Manufacturer Resources" item (previously called "Equipment Resources")
                //should display all Vendors as subitems that link to the Manufacturer Resources page
                //if (pageItem is EquipmentResourcesItem)
                //{
                //if (ItemReference.Radpac_EquipmentResources_Vendors.InnerItem != null)
                //{
                //    _alternateUrl = pageItem.NavUrl;
                //    IEnumerable<IListItem> vendorItems = ItemReference.Radpac_EquipmentResources_Vendors
                //        .InnerItem
                //        .Axes
                //        .GetDescendants()
                //        .Select(i => AcmeCustomItemInterfaces.GetItem<IListItem>(i));

                //    if (vendorItems.Count() > 0)
                //    {
                //        rptSubNav.DataSource = vendorItems;
                //        rptSubNav.DataBind();
                //    }
                //    //}
                //}
                //else
                //{
                List<IPageItem> subNavItems = NavUtil.GetMainSubNavItems(psItem.InnerItem);
                if (subNavItems.Count > 0)
                {
                    rptSubNav.DataSource = subNavItems;
                    rptSubNav.DataBind();
                }
                //}

                if (e.Item.ItemIndex == _navItems.Count - 1)
                {
                    liMain.Attributes["class"] = "last";
                }
            }
        }

        protected void rptSubNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hlSubNavItem = (HyperLink)e.Item.FindControl("hlSubNavItem");

                HtmlGenericControl liSub = (HtmlGenericControl)e.Item.FindControl("liSub");

                Repeater rptSubSubNav = (Repeater)e.Item.FindControl("rptSubSubNav");

                if (e.Item.DataItem is IListItem)
                {
                    IListItem listItem = (IListItem)e.Item.DataItem;

                    hlSubNavItem.Text = listItem.LiTitle;
                    hlSubNavItem.NavigateUrl = _alternateUrl;
                }
                else
                {
                    IPageItem pageItem = (IPageItem)e.Item.DataItem;
                    hlSubNavItem.Text = pageItem.NavTitle;
                    if (e.Item.DataItem is ListPageItem)
                    {
                        ListPageItem listPage = (ListPageItem)e.Item.DataItem;
                        PageSettingsItem psItem = ((ListPageItem)(e.Item.DataItem)).PageSettings;
                        
                        if (listPage.DocumentUrl.Url != "")
                        {
                            if (psItem.RequiresUserLogin)
                            {
                                 // Redirect the user if he's authenticated already                
                              if( !_isUserAuthorized)
                              {
                                    string url = "http://" + HttpContext.Current.Request.Url.Host + "/";
                                    if (Request.RawUrl != null)
                                      //  if (Request.RawUrl.ToString().ToUpper().Contains("RADPAC"))
                                          //  url += "/RADPAC/";
                                    url += "Login Page?documentPath=";
                                   // url+=((ListPageItem)e.Item.DataItem).DocumentUrl.Url;
                                    string ssoUrl = AuthenticationUtil.ConstructSSOUrlWithPrompt(url);
                                    hlSubNavItem.NavigateUrl = ssoUrl;
                              }

                              else if (((ListPageItem)e.Item.DataItem).DocumentUrl.Field.IsMediaLink)
                              {
                                  MediaItem mediaItem = ((ListPageItem) e.Item.DataItem).DocumentUrl.Field.TargetItem;
                                  hlSubNavItem.NavigateUrl = mediaItem != null ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem) : string.Empty;
                                hlSubNavItem.Target = "_blank";
                             }
                         }
                         else
                            {
                                MediaItem mediaItem = ((ListPageItem) e.Item.DataItem).DocumentUrl.Field.TargetItem;
																hlSubNavItem.NavigateUrl = mediaItem != null ? Sitecore.Resources.Media.MediaManager.GetMediaUrl(mediaItem) : string.Empty;
																hlSubNavItem.Target = "_blank";
                             }  
                            
                        }
                        else
                            hlSubNavItem.NavigateUrl = pageItem.NavUrl;
                    }
                    else
                    hlSubNavItem.NavigateUrl = pageItem .NavUrl ;
                     

                }

                if (e.Item.DataItem is ListPageItem)
                    GenerateSubSubNavigation(e, rptSubSubNav);

            }
            }

private static bool IsUserAuthorized()
{

    // Check SSO state
    bool isUserAuthorized = false;
    if (UserManager.CurrentUserContext.CurrentCustomerToken != null && UserManager.CurrentUserContext.CurrentCustomerToken != "")
    {
        if (!UserManager.CurrentUserContext.CurrentUser.IsInternationalUser)
            isUserAuthorized = true;
    }
    else
    {
        isUserAuthorized = AcrSsoUtil.IsAuthorized(HttpContext.Current, Sitecore.Context.Item);
    }


    return isUserAuthorized;
    //else
    //{
    // return   AcrSsoUtil.IsAuthorized(HttpContext.Current, Sitecore.Context.Item);
    //}
    
    // Check Authorization
    //if (!UserIsAuthorized())
    //{
    //    Response.Redirect(ItemReference.ACR_Error_401.Url, true);
    //    return;
    //}

                              
}
      

        private static void GenerateSubSubNavigation(RepeaterItemEventArgs e, Repeater rptSubSubNav)
        {
            ListPageItem listPageItem = (ListPageItem)e.Item.DataItem;
           
            List<Item> childrenItems = NavUtil.GetViewableChildren(listPageItem.InnerItem);
            List<IPageItem> subSubNavItems=new List<IPageItem> () ;
           
            if (childrenItems.Count > 0)
            {
                foreach (Item item in childrenItems)
                {

                    ListPageItem subListpageItem = (ListPageItem)item;

                    if (subListpageItem != null)
                    {
                        if (subListpageItem.DisplayInSubNav.Checked)
                        {                           
                            subSubNavItems.Add(subListpageItem);
                        }
                    }
                }

                if (subSubNavItems != null && subSubNavItems.Count > 0)
                {
                    rptSubSubNav.DataSource = subSubNavItems;
                    rptSubSubNav.DataBind();
                }
            }
        }

        protected void rptSubSubNav_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HyperLink hlSubSubNavItem = (HyperLink)e.Item.FindControl("hlSubSubNavItem");

                HtmlGenericControl liSub = (HtmlGenericControl)e.Item.FindControl("liSub");



                if (e.Item.DataItem is IListItem)
                {
                    IListItem listItem = (IListItem)e.Item.DataItem;

                    hlSubSubNavItem.Text = listItem.LiTitle;
                    hlSubSubNavItem.NavigateUrl = _alternateUrl;
                }
                else
                {
                    
                    IPageItem pageItem = (IPageItem)e.Item.DataItem;
                    hlSubSubNavItem.Text = pageItem.NavTitle;
                    if (e.Item.DataItem is ListPageItem)
                    {
                        ListPageItem listPage = (ListPageItem)e.Item.DataItem;
                        PageSettingsItem psItem = ((ListPageItem)(e.Item.DataItem)).PageSettings;

                        if (listPage.DocumentUrl.Url != "")
                        {
                            //check if page requires login
                            if (psItem.RequiresUserLogin)
                            {
                                // Redirect the user if he's not authenticated already                
                                if (!_isUserAuthorized)
                                {
                                    string url = "http://" + HttpContext.Current.Request.Url.Host + "/";
                                    if (Request.RawUrl != null)
                                       // if (Request.RawUrl.ToString().ToUpper().Contains("RADPAC"))
                                           // url += "/RADPAC/";
                                    url += "Login Page?documentPath=";
                                   // url += ((ListPageItem)e.Item.DataItem).DocumentUrl.Url;
                                    string ssoUrl = AuthenticationUtil.ConstructSSOUrlWithPrompt( url);
                                    hlSubSubNavItem.NavigateUrl = ssoUrl;
                                }

                                else
                                {
                                    if (((ListPageItem)e.Item.DataItem).DocumentUrl.Field.IsMediaLink)
                                    {
                                    	hlSubSubNavItem.NavigateUrl =
                                    		(((ListPageItem) e.Item.DataItem).DocumentUrl.Field.TargetItem != null)
                                    			? Sitecore.Resources.Media.MediaManager.GetMediaUrl(
                                    				((ListPageItem) e.Item.DataItem).DocumentUrl.Field.TargetItem)
                                    			: string.Empty;
                                    }
                                    else
                                    {
                                        hlSubSubNavItem.NavigateUrl = ((ListPageItem)e.Item.DataItem).DocumentUrl.Url;
                                    }
                                    hlSubSubNavItem.Target = "_blank";
                                }
                            }
                            else
                            {
                                if (((ListPageItem)e.Item.DataItem).DocumentUrl.Field.IsMediaLink)
                                {
                                	hlSubSubNavItem.NavigateUrl =
                                		(((ListPageItem) e.Item.DataItem).DocumentUrl.Field.TargetItem != null)
                                			? Sitecore.Resources.Media.MediaManager.GetMediaUrl(
                                				((ListPageItem) e.Item.DataItem).DocumentUrl.Field.TargetItem)
                                			: string.Empty;
                                }
                                else
                                {
                                    hlSubSubNavItem.NavigateUrl = ((ListPageItem) e.Item.DataItem).DocumentUrl.Url;
                                }
                            }
                            hlSubSubNavItem.Target = "_blank";
                        }
                                            
                        else
                            hlSubSubNavItem.NavigateUrl = pageItem.NavUrl;
                    }
                    else
                        hlSubSubNavItem.NavigateUrl = pageItem.NavUrl ;
                   

                }

            }
        }
    }
}