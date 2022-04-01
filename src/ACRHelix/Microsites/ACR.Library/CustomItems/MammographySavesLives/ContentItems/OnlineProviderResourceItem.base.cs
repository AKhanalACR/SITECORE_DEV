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
public partial class OnlineProviderResourceItem : CustomItem
{

public static readonly string TemplateId = "{5713299B-068E-4B96-A023-5F47FD18666B}";


#region Boilerplate CustomItem Code

public OnlineProviderResourceItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator OnlineProviderResourceItem(Item innerItem)
{
	return innerItem != null ? new OnlineProviderResourceItem(innerItem) : null;
}

public static implicit operator Item(OnlineProviderResourceItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField LinkText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Text"]);
	}
}


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