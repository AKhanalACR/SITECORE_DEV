using System;
using System.Web.UI.HtmlControls;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Reference;


namespace ACR.controls.RLI
{
	public partial class AddThisBodyWidget : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			//AddThisSettingsItem settings = AddThisSettings.GetItem();

			string addThisScriptUrl;
			if (Request.Url.Scheme == "https")
			{
				addThisScriptUrl = string.Format("https://s7.addthis.com/js/300/addthis_widget.js#pubid={0}", "RLI");
			}
			else
			{
				addThisScriptUrl = string.Format("http://s7.addthis.com/js/300/addthis_widget.js#pubid={0}", "RLI");
			}
			hlAddThis.NavigateUrl = string.Format("http://www.addthis.com/bookmark.php?v=300&amp;pubid={0}", "RLI");
			HtmlGenericControl addThisInclude = new HtmlGenericControl("script");
			addThisInclude.Attributes.Add("type", "text/javascript");
			addThisInclude.Attributes.Add("src", addThisScriptUrl);
			plcAddThis.Controls.Add(addThisInclude);
		}
	}
}