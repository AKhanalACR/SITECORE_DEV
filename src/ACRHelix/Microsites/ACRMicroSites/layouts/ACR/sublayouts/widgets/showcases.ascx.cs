using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore.Data.Items;

namespace ACR.layouts.ACR.sublayouts.widgets
{
    public partial class showcases : System.Web.UI.UserControl
    {
        public static string AllItemsText { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(AllItemsText))
                AllItemsText = "All";

            //get the home item
            Item showcases = Sitecore.Context.Database.GetItem("{56FF0C29-9EBB-44DB-94B9-2649BB056748}");

            //get all children from home using Sitecore API
            Item[] children = showcases.Children.ToArray();

            BindTabs(showcases.Parent.Axes.GetDescendants(), showcases.ID.ToString());
            BindShowcases(showcases.Axes.GetDescendants());

           
        }

        private void BindTabs(IEnumerable<Item> children, string showcasesID)
        {
            var results = (from i in children
                           where ((i.TemplateID.ToString() == "{FE5DD826-48C6-436D-B87A-7C4210C7413B}") &&
                           (i.ID.ToString() == showcasesID ||
                           (i.ParentID.ToString() == showcasesID)))
                           select i);

            Tabs.DataSource = results;
            Tabs.DataBind();
        }

        protected void Locale_Click(object sender, EventArgs e)
        {
            var lb = (LinkButton)sender;
            var showcaseImages = Sitecore.Context.Database.GetItem(lb.CommandArgument);
            BindShowcases(showcaseImages.Axes.GetDescendants());
        }

        private void BindShowcases(IEnumerable<Item> children)
        {
            // unversioned, Image or jpeg, versioned image or jpeg
            var results = (from i in children
                           where ((i.TemplateID.ToString() == "{F1828A2C-7E5D-4BBD-98CA-320474871548}") ||
                           (i.TemplateID.ToString() == "{DAF085E8-602E-43A6-8299-038FF171349F}") ||
                           (i.TemplateID.ToString() == "{C97BA923-8009-4858-BDD5-D8BE5FCCECF7}") ||
                           (i.TemplateID.ToString() == "{EB3FB96C-D56B-4AC9-97F8-F07B24BB9BF7}"))
                           select i);

            Showcases.DataSource = results;
            Showcases.DataBind();
        }

        public static string GetMediaUrl(Item item, Sitecore.Resources.Media.MediaUrlOptions options)
        {
            string result = null;
            var mediaUrl = Sitecore.Resources.Media.MediaManager.GetMediaUrl(item, options);
            if (!string.IsNullOrEmpty(mediaUrl))
            {
                result = Sitecore.Resources.Media.HashingUtils.ProtectAssetUrl(mediaUrl);
            }
            return result;
        }

        protected void Tabs_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex == 0)
            {
                var lb = (LinkButton)e.Item.FindControl("Locale");
                lb.Text = AllItemsText;
            }
        }
    }
}