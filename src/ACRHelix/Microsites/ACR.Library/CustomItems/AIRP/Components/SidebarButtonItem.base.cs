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
public partial class SidebarButtonItem : CustomItem
{

public static readonly string TemplateId = "{AAB19B61-09EB-4610-85A8-11925D5A1143}";


#region Boilerplate CustomItem Code

public SidebarButtonItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SidebarButtonItem(Item innerItem)
{
	return innerItem != null ? new SidebarButtonItem(innerItem) : null;
}

public static implicit operator Item(SidebarButtonItem customItem)
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


public CustomGeneralLinkField Link
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Link"]);
	}
}


public CustomImageField Icon
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Icon"]);
	}
}


#endregion //Field Instance Methods
}
}