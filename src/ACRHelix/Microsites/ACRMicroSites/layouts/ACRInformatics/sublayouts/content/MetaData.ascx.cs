using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;

namespace ACR.layouts.ACRInformatics.sublayouts.content
{
    public partial class MetaData : System.Web.UI.UserControl
    {
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string ogImage { get; set; }

        //public string ogTitle { get; set; }
        //public string ogMetaDescription { get; set; }
        //public string ogType { get; set; }
        //public string ogUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = string.IsNullOrWhiteSpace(Sitecore.Context.Item.Fields["Title"].Value) ? Sitecore.Context.Item.Name : Sitecore.Context.Item.Fields["Title"].Value;
            titleLt.Text = Server.HtmlEncode(Title);

            MetaDescription = MetaDescription ?? Sitecore.Context.Item.Fields["Description"].Value;
            descriptionLT.Text = "<meta name=\"description\" content=\"" + Server.HtmlEncode(MetaDescription) + "\" />";



            MetaKeywords = MetaKeywords ?? Sitecore.Context.Item.Fields["Keywords"].Value;
            keyWordsLT.Text = "<meta name=\"keywords\" content=\"" + Server.HtmlEncode(MetaKeywords) + "\" />";

            ogImage = ogImage ?? ImageHelper.getImageURLFromField(Sitecore.Context.Item, "OG Image");

            ogImageLT.Text = "<meta property=\"og:image\" content=\"" + Server.HtmlEncode(ogImage) + "\" />";

            AddCanonicalTag();



            // Set these to defaults for now            
            //ogTitle = ogTitle ?? Title;
            //ogMetaDescription = ogMetaDescription ?? MetaDescription;
            //ogType = ogType ?? "";
            //ogUrl = ogUrl ?? "";  
        }

        private void AddCanonicalTag()
        {
            bool added = false;
            string canon = Sitecore.Context.Item.Fields["Canonical"].Value;
            if (!string.IsNullOrWhiteSpace(canon))
            {
                Item item = Utilities.GetItemByGuid(canon);
                if (item != null)
                {
                    canonicalTag.Text = "<link rel=\"canonical\" href=\"" + ItemHelper.GetExtensionlessUrl(item) + "\" />";
                    added = true;
                }
            }
            if (!added)
            {
                canonicalTag.Text = "<link rel=\"canonical\" href=\"" + ItemHelper.GetExtensionlessUrl(Sitecore.Context.Item) + "\" />";
            }
        }
    }
}