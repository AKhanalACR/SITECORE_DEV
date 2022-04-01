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
public partial class _hasResearchItemsItem : CustomItem
{
public static readonly string TemplateId = "{98EC175B-2029-44EA-88C9-3E3D0E7AE86D}";

#region Boilerplate CustomItem Code

public _hasResearchItemsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasResearchItemsItem(Item innerItem)
{
	return innerItem != null ? new _hasResearchItemsItem(innerItem) : null;
}

public static implicit operator Item(_hasResearchItemsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField ResearchItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Research Items"]);
	}
}


#endregion //Field Instance Methods
}
}