using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ImageWisely.CustomItems.ImageWisely.Base;


namespace ACR.Library.ImageWisely.CustomItems.ImageWisely.Pages
{
public partial class PledgeLandingItem : CustomItem
{
public static readonly string TemplateId = "{9C653DD2-385E-4B97-93A3-50929A98480C}";
#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public PledgeLandingItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);
	_MetadataItem = new MetadataItem(innerItem);
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator PledgeLandingItem(Item innerItem)
{
	return innerItem != null ? new PledgeLandingItem(innerItem) : null;
}

public static implicit operator Item(PledgeLandingItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField TextBeneathPledgeOptions
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Text Beneath Pledge Options"]);
	}
}


#endregion //Field Instance Methods
}
}