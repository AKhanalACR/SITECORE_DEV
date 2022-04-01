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
public partial class _categorizableItem : CustomItem
{
public static readonly string TemplateId = "{5D9FE3D6-ADAC-4D7E-8CEA-F82258D8454E}";

#region Boilerplate CustomItem Code

public _categorizableItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _categorizableItem(Item innerItem)
{
	return innerItem != null ? new _categorizableItem(innerItem) : null;
}

public static implicit operator Item(_categorizableItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomLookupField Category
{
	get
	{
		return new CustomLookupField(InnerItem, InnerItem.Fields["Category"]);
	}
}


#endregion //Field Instance Methods
}
}