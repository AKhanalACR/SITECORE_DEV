using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.ACR.Products;
using ACR.Library.ACR.Taxonomy;
using ACR.Library.Common.Interfaces.Factory;
using Sitecore.Data.Items;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface IAcrProtectedContent
	{
		bool RequiresMembership { get; }
		List<ProductStubItem> RequiresProducts { get; }
		List<PersonifyTaxonomyItem> RequiresRoles{ get; }
	}
}
