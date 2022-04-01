using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MammographySavesLives.ContentItems
{
public partial class LinkItem : CustomItem
{

public static readonly string TemplateId = "{5713299B-068E-4B96-A023-5F47FD18666B}";


#region Boilerplate CustomItem Code

public LinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator LinkItem(Item innerItem)
{
	return innerItem != null ? new LinkItem(innerItem) : null;
}

public static implicit operator Item(LinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


#endregion //Field Instance Methods
}
}