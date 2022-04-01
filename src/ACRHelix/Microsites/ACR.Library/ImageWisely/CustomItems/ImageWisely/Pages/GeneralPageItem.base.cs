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
public partial class GeneralPageItem : CustomItem
{
public static readonly string TemplateId = "{FEFAD87F-FEDE-4A96-952E-E06A088D9F06}";
#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public GeneralPageItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);
	_MetadataItem = new MetadataItem(innerItem);
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator GeneralPageItem(Item innerItem)
{
	return innerItem != null ? new GeneralPageItem(innerItem) : null;
}

public static implicit operator Item(GeneralPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomGeneralLinkField PDFLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["PDF Link"]);
	}
}


#endregion //Field Instance Methods
}
}