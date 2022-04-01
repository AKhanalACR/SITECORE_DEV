using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Base
{
public partial class OrganizationItem : CustomItem
{
public static readonly string TemplateId = "{3D61D1F7-3591-485A-9659-21D88FE4240A}";

#region Boilerplate CustomItem Code

public OrganizationItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator OrganizationItem(Item innerItem)
{
	return innerItem != null ? new OrganizationItem(innerItem) : null;
}

public static implicit operator Item(OrganizationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField OrganizationName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Organization Name"]);
	}
}


public CustomGeneralLinkField OrganizationUrl
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Organization Url"]);
	}
}


public CustomTextField OrganizationDescription
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Organization Description"]);
	}
}


public CustomImageField Thumbnail
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Thumbnail"]);
	}
}


#endregion //Field Instance Methods
}
}