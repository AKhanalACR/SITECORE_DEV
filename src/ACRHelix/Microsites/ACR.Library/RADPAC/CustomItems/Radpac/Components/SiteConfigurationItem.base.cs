using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.Radpac.CustomItems.Radpac.Components
{
public partial class SiteConfigurationItem : CustomItem
{
    public static readonly string TemplateId = "{D13BFB96-7A92-4CE3-89BA-7355988CC5B5}";

#region Boilerplate CustomItem Code

public SiteConfigurationItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator SiteConfigurationItem(Item innerItem)
{
	return innerItem != null ? new SiteConfigurationItem(innerItem) : null;
}

public static implicit operator Item(SiteConfigurationItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField SiteName
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Site Name"]);
	}
}


public CustomTextField PageTitleSuffix
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Page Title Suffix"]);
	}
}


public CustomImageField HeaderImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Header Image"]);
	}
}


public CustomTextField FooterContent
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Footer Content"]);
	}
}


#endregion //Field Instance Methods
}
}