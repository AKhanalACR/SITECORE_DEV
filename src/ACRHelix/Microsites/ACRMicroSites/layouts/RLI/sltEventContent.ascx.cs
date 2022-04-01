using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Base;
using ACR.Library.Utils;

namespace ACR.layouts.RLI
{
	public partial class sltEventContent : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			EventBaseItem item = Sitecore.Context.Item;
			if(item == null)
			{
				return;
			}
			litTitle.Text = item.EventTitle;
			litSubtitle.Text = string.Join(" &#8226; ", new[] {item.EventTitle, DateTimeUtils.FormatRLIEventDateTime(item), item.LecturerName.Text, item.Location ?? "Online"}.Where(str => str != string.Empty).ToArray());
			litBody.Text = item.EventBody;
			if (string.IsNullOrEmpty(item.RegistrationLink.Url))
			{
				hlRegister.Visible = false;
			}
			else
			{
				hlRegister.NavigateUrl = LinkUtils.GetLinkFieldUrl(item.RegistrationLink.Field);
				hlRegister.Target = item.RegistrationLink.Field.Target;
			}
		}
	}
}