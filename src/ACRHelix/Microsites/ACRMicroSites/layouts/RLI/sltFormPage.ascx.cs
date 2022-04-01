using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ACR.Library.ACR.Base;
using ACR.Library.Common.Interfaces;
using ACR.Library.CustomItems.ACR.Interface;
using ACR.Library.CustomItems.ACR.Pages;
using ACR.Library.RLI.Pages;
using ACR.Library.Reference;
using Velir.SitecoreLibrary.Extensions;

namespace ACR.layouts.RLI
{
	public partial class sltFormPage : System.Web.UI.UserControl
	{
		protected WFMFormPageItem Model { get; private set; }

		protected void Page_Init(object sender, EventArgs e)
		{
			if (!Sitecore.Context.Item.IsOfTemplate(RLIWFMFormPageItem.TemplateId, 2))
			{
				Response.Redirect(ItemReference.ACR_Error_404.Url, true);
				Visible = false;
				return;
			}

			Model = Sitecore.Context.Item;

			IAcrContent contentItem = Model.BasicContentPage;
		}
	}
}