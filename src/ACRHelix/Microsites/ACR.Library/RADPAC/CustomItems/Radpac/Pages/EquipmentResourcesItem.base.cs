using System;
using Sitecore.Data.Items;
using ACR.Library.Radpac.CustomItems.Radpac.Base;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
public partial class EquipmentResourcesItem : CustomItem
{
    public static readonly string TemplateId = "{E8F6F442-D2CE-4AF1-BD0C-994707EF2F08}";
#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public EquipmentResourcesItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);
	_MetadataItem = new MetadataItem(innerItem);
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator EquipmentResourcesItem(Item innerItem)
{
	return innerItem != null ? new EquipmentResourcesItem(innerItem) : null;
}

public static implicit operator Item(EquipmentResourcesItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}