using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Globals
{
	public partial class EnumerationItem 
	{
		public string GetName()
		{
			return !string.IsNullOrEmpty(DisplayName) ? DisplayName : Name;
		}
	}
}