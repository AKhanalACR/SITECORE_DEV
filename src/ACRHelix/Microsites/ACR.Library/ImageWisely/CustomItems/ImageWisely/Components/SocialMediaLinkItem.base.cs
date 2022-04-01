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
public partial class SocialMediaLinkItem : CustomItem
{
public static readonly string TemplateId = "{800CA21A-2F93-4E5A-8E2A-8E0D881891F1}";


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


public CustomTextField LinkUrl
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Link Url"]);
	}
}


#endregion //Field Instance Methods
}
}