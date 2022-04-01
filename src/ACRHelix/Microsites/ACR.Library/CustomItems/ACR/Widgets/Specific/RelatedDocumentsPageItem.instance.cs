using System;
using ACR.Library.ACR.Products;
using ACR.Library.Common.Interfaces;
using ACR.Library.Common.Interfaces.Factory;
using ACR.Library.Reference;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;

namespace ACR.Library.ACR.Base
{
	public partial class RelatedDocumentsPageItem 
	{
		public IList<IListItem> GetResourceItems()
		{
			if (RelatedResources == null
				|| RelatedResources.ListItems == null
				|| RelatedResources.ListItems.Count < 1)
			{
				return new List<IListItem>();
			}
			return ItemInterfaceFactory.GetItems<IListItem>(RelatedResources.ListItems);
		}
	}
}