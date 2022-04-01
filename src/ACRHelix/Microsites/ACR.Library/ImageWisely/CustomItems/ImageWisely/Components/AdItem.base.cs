using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Components
{
public partial class AdItem : CustomItem
{

public static readonly string TemplateId = "{E8322038-4B97-4DC5-951D-6FB2883A7637}";


#region Boilerplate CustomItem Code

public AdItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator AdItem(Item innerItem)
{
	return innerItem != null ? new AdItem(innerItem) : null;
}

public static implicit operator Item(AdItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField AdImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Ad Image"]);
	}
}


public CustomGeneralLinkField AdURL
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Ad URL"]);
	}
}


#endregion //Field Instance Methods
}
}