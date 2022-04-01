using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages;
using ACR.Library.Reference;
using Sitecore.Data.Fields;

namespace ACR.controls.ImageWisely
{
	public partial class Callout : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		    if (Sitecore.Context.Item.TemplateID.ToString() != HomePageItem.TemplateId)
		    {
		        return;
		    }

		    HomePageItem homeItem = ItemReference.ImageWisely.InnerItem;
            CalloutText.Text = homeItem.CalloutText.Rendered;
		    CalloutButton.Text = homeItem.CalloutButton.Rendered;
		}
	}
}