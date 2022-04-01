using System;
using ACR.Library.Common.Interfaces.Factory;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;

namespace ACR.Library.Common.Interfaces
{
	[FactoryInterface]
	public interface IListItemFeaturedParent
	{
		bool liSuppressParentPageFeature { get; }
		CustomImageField liParentPageThumbnail { get; }
		CustomTextField liParentPageIntroText { get; }
		CustomTextField liPageTitle { get; }
		string NavUrl { get; }
		bool liIsExternal { get; }
	}
}
