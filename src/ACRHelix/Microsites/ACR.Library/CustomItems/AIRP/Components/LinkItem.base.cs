using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.AIRP.Components
{
public partial class LinkItem : CustomItem
{

public static readonly string TemplateId = "{58E60C7A-C83E-4401-81CE-D48903C0F02D}";


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