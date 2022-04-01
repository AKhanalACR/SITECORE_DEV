using System;
using ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class NavigationMenuItem : CustomItem
{
public static readonly string TemplateId = "{2E209CB0-E0FA-4995-9DD6-CFC79B01305B}";
#region Inherited Base Templates

private readonly _menuItem __menuItem;
public _menuItem menu { get { return __menuItem; } }

#endregion

#region Boilerplate CustomItem Code

public NavigationMenuItem(Item innerItem) : base(innerItem)
{
	__menuItem = new _menuItem(innerItem);

}

public static implicit operator NavigationMenuItem(Item innerItem)
{
	return innerItem != null ? new NavigationMenuItem(innerItem) : null;
}

public static implicit operator Item(NavigationMenuItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}