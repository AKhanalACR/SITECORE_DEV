using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.MammographySavesLives.DataTemplates;

namespace ACR.controls.MammographySavesLives
{
	public partial class TwitterWidget : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			_hasTwitterWidgetItem currentItem = Sitecore.Context.Item;

			if (!string.IsNullOrEmpty(currentItem.TwitterWidgetTitle.Raw))
			{
				litComponentTitle.Text = currentItem.TwitterWidgetTitle.Text;
			}

			if(currentItem != null && !string.IsNullOrEmpty(currentItem.TwitterWidgetEmbedCode.Raw))
			{
				phTwitterWidget.Visible = true;
				litTwitterWidget.Text = currentItem.TwitterWidgetEmbedCode.Raw;
			}
		}
	}
}