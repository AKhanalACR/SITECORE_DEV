using System;
using System.Linq;
using ACR.Library.Utils;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.CodingSource
{
	public partial class CodingSourceListItem
	{
		public List<CodingSourceYearFolderItem> GetYears()
		{
			return InnerItem.GetChildren().Select(i => new CodingSourceYearFolderItem(i)).OrderByDescending(i => int.Parse(i.Year.Text)).ToList();
		}

		public CodingSourceYearFolderItem GetYear(string s)
		{
			return GetYears().FirstOrDefault(i => i.Year.Text == s);
		}
	}
}