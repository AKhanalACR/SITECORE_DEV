using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.Radpac.CustomItems.Radpac.Base;

namespace ACR.Library.Radpac.CustomItems.Radpac.Pages
{
public partial class ListPageItem : CustomItem
{
    public static readonly string TemplateId = "{8B9FEABE-9E3A-4366-A29B-FB97F847CAA4}";
#region Inherited Base Templates

private readonly PageSettingsItem _PageSettingsItem;
public PageSettingsItem PageSettings { get { return _PageSettingsItem; } }
private readonly MetadataItem _MetadataItem;
public MetadataItem Metadata { get { return _MetadataItem; } }
private readonly ContentPageItem _ContentPageItem;
public ContentPageItem ContentPage { get { return _ContentPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ListPageItem(Item innerItem) : base(innerItem)
{
	_PageSettingsItem = new PageSettingsItem(innerItem);
	_MetadataItem = new MetadataItem(innerItem);
	_ContentPageItem = new ContentPageItem(innerItem);

}

public static implicit operator ListPageItem(Item innerItem)
{
	return innerItem != null ? new ListPageItem(innerItem) : null;
}

public static implicit operator Item(ListPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomCheckboxField DisplayTopicLinks
{
	get
	{
		return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display Topic Links"]);
	}
}

public CustomCheckboxField DisplayInSubNav
{
    get
    {
        return new CustomCheckboxField(InnerItem, InnerItem.Fields["Display in SubNavigation"]);
    }
}

public CustomGeneralLinkField DocumentUrl
{
    get
    {
        return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["DocumentUrl"]);
    }
}


#endregion //Field Instance Methods
}
}