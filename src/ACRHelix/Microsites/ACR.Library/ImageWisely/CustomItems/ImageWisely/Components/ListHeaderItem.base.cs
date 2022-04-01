using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class ListHeaderItem : CustomItem
{
public static readonly string TemplateId = "{164D41C1-A325-4165-A6DC-45B8DF23C788}";

#region Boilerplate CustomItem Code

public ListHeaderItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ListHeaderItem(Item innerItem)
{
	return innerItem != null ? new ListHeaderItem(innerItem) : null;
}

public static implicit operator Item(ListHeaderItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Title"]);
	}
}


#endregion //Field Instance Methods
}
}