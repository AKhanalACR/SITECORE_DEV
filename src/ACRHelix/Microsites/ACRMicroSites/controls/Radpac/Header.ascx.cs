using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library;
using ACR.Library.Radpac.CustomItems.Radpac.Components;
using ACR.Library.Reference;
using ACR.Library.Utils;

namespace ACR.controls.Radpac
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
		   if (ItemReference.Radpac_Global_SiteConfigurationSettings.InnerItem != null)
            {
                SiteConfigurationItem siteConfigItem = ItemReference.Radpac_Global_SiteConfigurationSettings.InnerItem;

                if (siteConfigItem.HeaderImage != null)
                    imgLogo.Initialize(siteConfigItem.HeaderImage.MediaItem);
            }

            if (IsPostBack)
                return;

           // txtSearch.Attributes.Add("onclick", "if(this.value == 'Search'){this.value=''; this.style.color='#000';}");
        }

        //protected void buttonSearch_Click(object sender, EventArgs e)
        //{
            //if (txtSearch.Text.Trim() != String.Empty)
            //{

            //    string searchTerms = Server.UrlEncode(txtSearch.Text.Trim());

            //    var resultUrl = "/Search.aspx" + SearchUtil.BuildSearchUrlParameters(
            //        AcrGlobals.GSASettings["Collection.Radpac.EntireSite"],
            //        null,
            //        null,
            //        AcrGlobals.SEARCH_PAGINATION_PAGESIZE,
            //        SearchMode.Relevance,
            //        String.Empty,
            //        searchTerms,
            //        String.Empty,
            //        String.Empty,
            //        null,
            //        null);
            //    Response.Redirect(resultUrl);

            //}
        //}
    }
}