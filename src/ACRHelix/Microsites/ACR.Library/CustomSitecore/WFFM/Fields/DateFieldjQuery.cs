using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ACR.Library.CustomSitecore.WFFM.Fields
{

	public class DateFieldjQuery : Sitecore.Form.Web.UI.Controls.SingleLineText
	{
		protected override void OnPreRender(EventArgs e)
		{
			this.textbox.CssClass += " wffmDatePicker";
			string script = "jQuery(document).ready(function() {jQuery(\".wffmDatePicker\").datepicker();});";
			this.Page.ClientScript.RegisterStartupScript(this.GetType(),
				"ACR.Library.CustomSitecore.WFFM.Fields.DateFieldjQuery", 
				script, true);
		}
	}
}
