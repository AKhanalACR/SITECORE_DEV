using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.AIRP.Base;
using ACR.Library.AIRP.Pages;

namespace ACR.layouts.AIRP
{
	public partial class LytGeneralPage : System.Web.UI.Page
	{
		protected string keywords;
		protected void Page_Load(object sender, EventArgs e)
		{
			PageBaseItem item = Sitecore.Context.Item;
			if(item == null)
			{
				return;
			}
			litTitle.Text = item.DisplayName;
			keywords = item.Metadata.Text;
		}
	}
}