using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class FooterLogosItem : CustomItem
{
public static readonly string TemplateId = "{180E0378-31B1-4E57-8FB7-4F1CB8CD81B6}";

#region Boilerplate CustomItem Code

public FooterLogosItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator FooterLogosItem(Item innerItem)
{
	return innerItem != null ? new FooterLogosItem(innerItem) : null;
}

public static implicit operator Item(FooterLogosItem customItem)
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


public CustomGeneralLinkField FooterLogoLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Footer Logo Link"]);
	}
}


#endregion //Field Instance Methods
}
}