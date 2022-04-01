using System;
using System.Linq;
using ACR.Library.CustomSitecore.Extensions;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.MediaCenter
{
	public partial class SpokespersonsFolderItem
	{
		/// <summary>
		/// Will return the spokespersons under this folder.
		/// </summary>
		/// <returns>All spokespersons under this folder.</returns>
		public List<SpokespersonItem> GetSpokespersons()
		{
			return InnerItem.GetChildrenByTemplate(SpokespersonItem.TemplateId).Select(i => (SpokespersonItem)i).ToList();
		}

		/// <summary>
		/// Will get only the featured spokespersons under this folder.
		/// </summary>
		/// <returns>The featured spokespersons.</returns>
		public List<SpokespersonItem> GetFeaturedSpokespersons()
		{
			//get our spokespersons
			List<SpokespersonItem> spokespersons = GetSpokespersons();

			//grab only our featured spokespersons
			spokespersons = spokespersons.Where(i => i.FeaturedSpokesperson.Checked).ToList();

			//return our spokespersons
			return spokespersons;
		}
	}
}