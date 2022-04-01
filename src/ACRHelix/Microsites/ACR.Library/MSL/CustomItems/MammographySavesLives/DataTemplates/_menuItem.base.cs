using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates
{
public partial class _menuItem : CustomItem
{
public static readonly string TemplateId = "{43C5FC27-A33D-4D6E-AB5D-1FEE0B950309}";

#region Boilerplate CustomItem Code

public _menuItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _menuItem(Item innerItem)
{
	return innerItem != null ? new _menuItem(innerItem) : null;
}

public static implicit operator Item(_menuItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField MenuItems
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Menu Items"]);
	}
}


#endregion //Field Instance Methods
}
}