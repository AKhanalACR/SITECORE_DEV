using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Widgets.General
{
	public partial class VideoWidgetItem 
	{
		public bool HasContent()
		{
			return !string.IsNullOrEmpty(VideoContent.VideoId.Text);
		}
	}
}