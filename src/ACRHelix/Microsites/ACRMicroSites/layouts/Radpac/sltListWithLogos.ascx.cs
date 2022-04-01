using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using ACR.Library.Common.Interfaces.Factory;
using ACR.controls.Common;
using ACR.Library.Common.Interfaces;
using Common.Logging;

namespace ACR.layouts.Radpac
{
    public partial class sltListWithLogos : System.Web.UI.UserControl
    {
        private IEnumerable<IListItem> _allListItems;
        private IEnumerable<String> _allTopics;
        private int _headerCount;

        private static ILog _logger;

        private static ILog Logger
        {
            get
            {
                _logger = _logger ?? LogManager.GetLogger(typeof(sltListWithLogos));
                return _logger;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
							IListPage listPageItem = ItemInterfaceFactory.GetItem<IListPage>(Sitecore.Context.Item);
                _allListItems = listPageItem.ListItems;
                _allTopics = listPageItem.HeaderTitles;
            }
            catch (Exception ex)
            {
                Logger.Error("sltListWithLogos.apsx.cs: The context item may not implement the IListPage interface.", ex);
            }

            if (_allTopics != null)
            {
                _headerCount = 0;
                rptTopics.DataSource = _allTopics;
                rptTopics.DataBind();
            }
        }

        protected void RptTopicsItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                String listHeaderTitle = (String)e.Item.DataItem;
                if (listHeaderTitle == null) return;

                Literal ltlHeadingTitle = (Literal)e.Item.FindControl("ltlHeadingTitle");
                ltlHeadingTitle.Text = listHeaderTitle.ToUpper();

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
                if (String.IsNullOrEmpty(listItem.LiTitle) || String.IsNullOrEmpty(listItem.LiUrl)) return;


                HyperLink hlListItem = (HyperLink)e.Item.FindControl("hlListItem");
                Literal ltlDescription = (Literal)e.Item.FindControl("ltlDescription");
                SitecoreImage imgListItem = (SitecoreImage)e.Item.FindControl("imgListItem"); ;

                imgListItem.Initialize(listItem.LiImage, 300, 103);
                hlListItem.Text = "&raquo; " + listItem.LiTitle;
                hlListItem.NavigateUrl = listItem.LiUrl;
                hlListItem.Target = listItem.LiLinkTarget;
                ltlDescription.Text = listItem.LiDescription;

                if (listItem.LiIsPdf)
                {
                    Literal ltlIcon = (Literal)e.Item.FindControl("ltlIcon");
                    ltlIcon.Text = "<span class=\"floatnone\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>";
                }

            }
        }
    }
}