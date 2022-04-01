using System;
using ACR.Library.CustomItems.AIRP.Interfaces;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.AIRP.Pages
{
	public partial class InternalPageItem : IAIRPNav
	{
		public bool IncludeInTopNav
		{
			get { return Navigation.IncludeinNavigation.Checked; }
		}

		public string NavTitle
		{
			get { return Navigation.NavigationTitle.Text; }
		}
	}
}