using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP.Pages;

namespace ACR.layouts.AIRP
{
	public partial class sltContent : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			InternalPageItem item = Sitecore.Context.Item;
			if(item == null)
			{
				return;
			}
			litContent.Text = item.Body.Rendered;
			litTitle.Text = item.Title.Text;
		}
	}
}