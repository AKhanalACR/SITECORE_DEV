using ACR.Library.CustomItems.MammographySavesLives.DataTemplates;
using ACR.Library.MSL.CustomItems.MammographySavesLives.PageTemplates;
using Sitecore.Data.Items;
using ACR.Library.MammographySavesLives.DataTemplates;

namespace ACR.Library.CustomItems.MammographySavesLives.PageTemplates
{
public partial class ToolsAndResourcesPageItem : CustomItem
{

public static readonly string TemplateId = "{D2790E76-2838-4230-A83A-2688C98439A8}";

#region Inherited Base Templates

private readonly DetailPageItem _DetailPageItem;
public DetailPageItem DetailPage { get { return _DetailPageItem; } }
private readonly _hasMarketingMaterialsModuleItem __hasMarketingMaterialsModuleItem;
public _hasMarketingMaterialsModuleItem hasMarketingMaterialsModule { get { return __hasMarketingMaterialsModuleItem; } }
private readonly _hasNewsReleasesItem __hasNewsReleasesItem;
public _hasNewsReleasesItem hasNewsReleases { get { return __hasNewsReleasesItem; } }

#endregion

#region Boilerplate CustomItem Code

public ToolsAndResourcesPageItem(Item innerItem) : base(innerItem)
{
	_DetailPageItem = new DetailPageItem(innerItem);
	__hasMarketingMaterialsModuleItem = new _hasMarketingMaterialsModuleItem(innerItem);
	__hasNewsReleasesItem = new _hasNewsReleasesItem(innerItem);

}

public static implicit operator ToolsAndResourcesPageItem(Item innerItem)
{
	return innerItem != null ? new ToolsAndResourcesPageItem(innerItem) : null;
}

public static implicit operator Item(ToolsAndResourcesPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}