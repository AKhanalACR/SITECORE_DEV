using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACR.Library.Common.Interfaces.Factory;
using Sitecore.Collections;

namespace ACR.Library.CustomItems.ACR.Interface
{
	[FactoryInterface]
	public interface ITaxonomyPage
	{
		SafeDictionary<string> BuildSafeDictionaryFromItem(string taxonomyType);
	}
}
