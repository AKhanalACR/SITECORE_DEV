using Sitecore.Data.Items;
using CustomItemGenerator.Fields.LinkTypes;

namespace ACR.Library.Common.CustomItems.AcrCommon
{
public partial class CustomDeviceItem : CustomItem
{
public static readonly string TemplateId = "{70FF19B6-812B-424C-87A3-3A838520298C}";
#region Inherited Base Templates

private readonly DeviceItem _DeviceItem;
public DeviceItem Device { get { return _DeviceItem; } }

#endregion

#region Boilerplate CustomItem Code

public CustomDeviceItem(Item innerItem) : base(innerItem)
{
	_DeviceItem = new DeviceItem(innerItem);

}

public static implicit operator CustomDeviceItem(Item innerItem)
{
	return innerItem != null ? new CustomDeviceItem(innerItem) : null;
}

public static implicit operator Item(CustomDeviceItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField SiteRoot
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Site Root"]);
	}
}


#endregion //Field Instance Methods
}
}