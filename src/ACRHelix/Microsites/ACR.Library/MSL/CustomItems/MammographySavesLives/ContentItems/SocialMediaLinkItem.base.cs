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
public partial class SocialMediaLinkItem : CustomItem
{
public static readonly string TemplateId = "{DF9FA35C-4396-4709-BE3E-E2F0C56668A4}";

#region Boilerplate CustomItem Code

public SocialMediaLinkItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SocialMediaLinkItem(Item innerItem)
{
	return innerItem != null ? new SocialMediaLinkItem(innerItem) : null;
}

public static implicit operator Item(SocialMediaLinkItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Logo
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Logo"]);
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