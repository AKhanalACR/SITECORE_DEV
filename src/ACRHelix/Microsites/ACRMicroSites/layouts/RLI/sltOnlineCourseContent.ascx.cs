using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.RLI.Base;
using ACR.Library.RLI.Pages;
using ACR.Library.RLI.Taxonomy;
using ACR.Library.Utils;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.layouts.RLI
{
	public partial class sltOnlineCourseContent : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

			OnlineCourseItem item = Sitecore.Context.Item;
			if (item == null)
			{
				return;
			}
			
			string date = DateTimeUtils.FormatRLIEventDateTime(item);
			litTitle.Text = item.EventTitle;
			litSubtitle.Text = string.Join(" &#8226; ", new[] {item.EventBase.EventTitle, String.Join(", ", item.LectureDaysOfWeek.Select(i=>i.Day.Text + "s").ToArray()), date, "Online"}.Where(str => str!= string.Empty).ToArray());
			litBody.Text = item.EventBase.EventBody;
			var link = LinkUtils.GetLinkFieldUrl(item.EventBase.RegistrationLink.Field);
		    if (string.IsNullOrEmpty(link))
		    {
		        hlParagraph.Visible = false;
		    }
		    else
		    {
		        hlRegister.NavigateUrl = link;
		        hlRegister.Target = item.EventBase.RegistrationLink.Field.Target;
		    }
		}
	}
}