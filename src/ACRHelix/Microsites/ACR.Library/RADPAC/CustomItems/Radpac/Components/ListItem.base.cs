using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.Radpac.CustomItems.Radpac.Components
{
public partial class ListItem : CustomItem
{
    public static readonly string TemplateId = "{433B00EE-60C7-49F6-AB83-18824D8EC205}";

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

public CustomImageField ListImage
{
    get
    {
        return new CustomImageField(InnerItem, InnerItem.Fields["List Item Image"]);
    }
}

#endregion //Field Instance Methods
}
}