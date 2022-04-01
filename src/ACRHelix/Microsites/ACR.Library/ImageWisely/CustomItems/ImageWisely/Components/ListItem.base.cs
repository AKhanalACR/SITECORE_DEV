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
public partial class ListItem : CustomItem
{
public static readonly string TemplateId = "{D43031E2-65D6-475D-B8F1-1B7F715263FA}";

#region Boilerplate CustomItem Code

public ListItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator ListItem(Item innerItem)
{
	return innerItem != null ? new ListItem(innerItem) : null;
}

public static implicit operator Item(ListItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField ListItemTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["List Item Title"]);
	}
}


public CustomGeneralLinkField ListItemUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["List Item Url"]);
	}
}


public CustomTextField ListItemDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["List Item Description"]);
	}
}


#endregion //Field Instance Methods
}
}