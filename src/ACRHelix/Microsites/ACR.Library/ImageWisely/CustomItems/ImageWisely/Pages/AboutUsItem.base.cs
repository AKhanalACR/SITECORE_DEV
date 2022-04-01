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
public partial class AboutUsItem : CustomItem
{
public static readonly string TemplateId = "{AB9D4D89-0D70-46FE-BD33-4B5E1E93F5CC}";
#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public AboutUsItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);
	_MetadataItem = new MetadataItem(innerItem);
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator AboutUsItem(Item innerItem)
{
	return innerItem != null ? new AboutUsItem(innerItem) : null;
}

public static implicit operator Item(AboutUsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField KeyContributorsTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Contributors Title"]);
	}
}


public CustomTextField KeyContributorsText
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Key Contributors Text"]);
	}
}


#endregion //Field Instance Methods
}
}