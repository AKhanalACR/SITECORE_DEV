using System;
using ACR.Library.Common.Interfaces.Factory;
using CustomItemGenerator.Fields.SimpleTypes;
using Sitecore.Data.Items;

namespace ACR.Library.Common.Interfaces
{
	[FactoryInterface]
	public interface INavigationItem
	{
		string NavShortTitle { get; }
		bool HideBreadcrumb { get; }
		bool ShowInTopNavigation { get; }
		bool ShowInSideNavigation { get; }
		bool ShowInFooter { get; }
		bool ShowInSitemap { get; }
		bool HideSideNavigation { get; }
		string NavUrl { get; }
		bool HideTextControl { get; }
		bool HideToolbarControl { get; }
	}
}
