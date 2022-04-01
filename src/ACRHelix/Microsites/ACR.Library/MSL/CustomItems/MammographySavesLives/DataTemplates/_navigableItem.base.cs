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
public partial class _navigableItem : CustomItem
{
public static readonly string TemplateId = "{236287AF-D11E-468D-9105-FC252754B8BD}";

#region Boilerplate CustomItem Code

public _navigableItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _navigableItem(Item innerItem)
{
	return innerItem != null ? new _navigableItem(innerItem) : null;
}

public static implicit operator Item(_navigableItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField BrowserTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Browser Title"]);
	}
}


public CustomTextField MenuTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Menu Title"]);
	}
}


public CustomTextField BreadcrumbTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Breadcrumb Title"]);
	}
}


public CustomMultiListField MetaKeywords
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Meta Keywords"]);
	}
}


public CustomTextField MetaDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Meta Description"]);
	}
}


public CustomCheckboxField ShowInMenu
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Show In Menu"]);
	}
}


#endregion //Field Instance Methods
}
}