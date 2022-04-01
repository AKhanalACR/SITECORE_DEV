using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Pages;

namespace ACR.layouts.RLI
{
	public partial class sltPressRelease : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			PressReleaseItem item = Sitecore.Context.Item;
			if(item == null)
			{
				return;
			}
			if (item.Date.DateTime != DateTime.MinValue)
			{
				litDate.Text = String.Format("{0:MMMM d, yyyy}", item.Date.DateTime);
			}
			litContent.Text = item.InternalPageBase.Body.Text;
		}
	}
}