using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.RLI.Components
{
public partial class LinkItem : CustomItem
{

public static readonly string TemplateId = "{90804C04-2C91-44CF-8954-8B0405DBA405}";


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


public CustomTextField LinkName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Name"]);
	}
}


public CustomGeneralLinkField LinkDestination
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link Destination"]);
	}
}


#endregion //Field Instance Methods
}
}