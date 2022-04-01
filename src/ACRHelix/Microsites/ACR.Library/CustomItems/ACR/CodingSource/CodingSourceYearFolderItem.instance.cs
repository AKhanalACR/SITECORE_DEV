using System;
using System.Linq;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.CodingSource
{
	public partial class CodingSourceYearFolderItem
	{
		public List<CodingSourceIndexItem> GetIndices()
		{
			if (InnerItem.HasChildren)
			{
				return InnerItem.GetChildren().Select(i => new CodingSourceIndexItem(i)).ToList();
			}
			return new List<CodingSourceIndexItem>();
		}
	}
}