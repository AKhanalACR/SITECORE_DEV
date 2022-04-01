using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class IconTypeItem : CustomItem
{
public static readonly string TemplateId = "{1A9A28CF-C69E-4F02-B642-3BE26F8E54EE}";

#region Boilerplate CustomItem Code

public IconTypeItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator IconTypeItem(Item innerItem)
{
	return innerItem != null ? new IconTypeItem(innerItem) : null;
}

public static implicit operator Item(IconTypeItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField IconType
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon Type"]);
	}
}


#endregion //Field Instance Methods
}
}