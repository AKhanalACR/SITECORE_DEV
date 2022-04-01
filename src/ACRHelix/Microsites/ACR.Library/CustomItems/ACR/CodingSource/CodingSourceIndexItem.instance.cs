using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.CodingSource
{
	public partial class CodingSourceIndexItem
	{
		public List<CodingSourceDetailPageItem> GetDetailPages()
		{
			return InnerItem.GetChildren().Select(i => new CodingSourceDetailPageItem(i)).ToList();;
		}
	}
}