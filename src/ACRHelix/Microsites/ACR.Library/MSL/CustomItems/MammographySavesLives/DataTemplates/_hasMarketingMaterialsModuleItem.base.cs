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
public partial class _hasMarketingMaterialsModuleItem : CustomItem
{
	public static readonly string TemplateId = "{C522A5D2-8967-48E3-BE59-F14CF0D0E393}";

#region Boilerplate CustomItem Code

public _hasMarketingMaterialsModuleItem(Item innerItem) : base(innerItem)
{
}

public static implicit operator _hasMarketingMaterialsModuleItem(Item innerItem)
{
	return innerItem != null ? new _hasMarketingMaterialsModuleItem(innerItem) : null;
}

public static implicit operator Item(_hasMarketingMaterialsModuleItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField MarketingMaterialsItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Marketing Materials Items"]);
	}
}


public CustomImageField MarketingMaterialsImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Marketing Materials Image"]);
	}
}


#endregion //Field Instance Methods
}
}