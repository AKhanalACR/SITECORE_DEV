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
public partial class _hasPromotionsItem : CustomItem
{
public static readonly string TemplateId = "{2381435A-EE48-4FFA-BDD4-5D81442E31B3}";

#region Boilerplate CustomItem Code

public _hasPromotionsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasPromotionsItem(Item innerItem)
{
	return innerItem != null ? new _hasPromotionsItem(innerItem) : null;
}

public static implicit operator Item(_hasPromotionsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField PromotionalItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Promotional Items"]);
	}
}


#endregion //Field Instance Methods
}
}