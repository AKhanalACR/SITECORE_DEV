using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Constants;
using ACRAccreditationInformaticsLibrary;
using Sitecore.Data.Items;
using Sitecore.Web.UI.WebControls;

namespace ACR.layouts.ACR.sublayouts.navigation
{
    public partial class Footer : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Item FooterItem = Utilities.GetItemByGuid(Types.Items.FooterNav);

            //topleft
            topLeftTitleFR.FieldName = Types.Fields.FooterMainLinkTL;

            bottomLeftTitleFR.FieldName = Types.Fields.FooterMainLinkBL;

            middleBottomMainLink.FieldName = Types.Fields.FooterMainLinkMB;


            //topRight
            topRightTitleFR.FieldName = Types.Fields.FooterMainLinkRT;

            //address
            footerAddressFR.FieldName = Types.Fields.FooterAddress;

            //login
            //footerLoginFR.FieldName = Types.Fields.FooterLogin;
            footerLoginLink.Field = Types.Fields.FooterLogin;


            //repeater Links
            bindLinksToRepeater(FooterItem, Types.Fields.FooterSectionLinksTL, topLeftSectionLinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterSectionLinksBL, bottomLeftSectionLinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterMainLinksMT, middleTopSectionLinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterSectionLinksMT, middleBotSectionLinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterSectionLinksRT, topRightSectionLinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterLinksRB, botRightSectionLinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterTopMobileLinks, topMobilelinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterBottomMobileLinks, bottomMobileLinksRpt);
            bindLinksToRepeater(FooterItem, Types.Fields.FooterSectionLinksMB, middleBottomSectionLinks);

            //set the item for all field renderers
            bindItemFieldRenderer(FooterItem);
        }

        private void bindLinksToRepeater(Item item, string fieldName, Repeater repeater)
        {
            List<FooterLink> links = GetItemLinks(ItemHelper.GetFieldValue(item, fieldName));
            repeater.DataSource = links;
            repeater.DataBind();
        }

        private void bindItemFieldRenderer(Item item)
        {
            foreach (Control c in this.Controls)
            {
                if (c.GetType() == typeof(FieldRenderer))
                {
                    FieldRenderer fr = (FieldRenderer)c;
                    fr.Item = item;
                }
                else if (c.GetType() == typeof(Text))
                {
                    Text link = (Text)c;
                    link.Item = item;
                }
            }
        }

        private void bindRepeater(List<FooterLink> datasource, Repeater repeater)
        {
            repeater.DataSource = datasource;
            repeater.DataBind();
        }

        private List<FooterLink> GetItemLinks(string linkValues)
        {
            List<FooterLink> links = new List<FooterLink>();
            string[] itemIDs = linkValues.Split(new char[] { '|' });
            foreach (string id in itemIDs)
            {
                Item item = Utilities.GetItemByGuid(id);
                if (item != null)
                {
                    string name = ItemHelper.GetFieldValueOrItemName(item, Types.Fields.NavNameOverride);//ItemHelper.getStringFieldWithFallback(Types.Fields.NavNameOverride, item.Name, item);
                    string link = ItemHelper.GetExtensionlessUrl(item);
                    links.Add(new FooterLink(name, link));
                }
            }
            return links;
        }


        public class FooterLink
        {
            public string Name { get; set; }
            public string LinkURL { get; set; }

            public FooterLink(string name, string linkUrl)
            {
                Name = name;
                LinkURL = linkUrl;
            }
        }
    }
}