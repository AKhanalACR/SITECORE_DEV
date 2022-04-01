using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class FooterLogoItem : CustomItem
{

public static readonly string TemplateId = "{AE90BAF7-C4B4-4E86-9B9B-A8F17CD35D35}";


#region Boilerplate CustomItem Code

public FooterLogoItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FooterLogoItem(Item innerItem)
{
	return innerItem != null ? new FooterLogoItem(innerItem) : null;
}

public static implicit operator Item(FooterLogoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField FooterLogo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Footer Logo"]);
	}
}

public static string FieldName_FooterLogo 
{
	get
	{
		return "Footer Logo";
	}
} 


public CustomGeneralLinkField FooterLogoLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Footer Logo Link"]);
	}
}

public static string FieldName_FooterLogoLink 
{
	get
	{
		return "Footer Logo Link";
	}
} 


#endregion //Field Instance Methods
}
}