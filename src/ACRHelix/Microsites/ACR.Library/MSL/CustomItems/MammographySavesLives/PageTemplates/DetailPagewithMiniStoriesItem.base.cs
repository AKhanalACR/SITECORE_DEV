using System;
using ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.PageTemplates
{
public partial class DetailPagewithMiniStoriesItem : CustomItem
{
public static readonly string TemplateId = "{49802F59-CA5E-44F4-97A9-BBD5FC2BEA2E}";
#region Inherited Base Templates

private readonly DetailPageItem _DetailPageItem;
public DetailPageItem DetailPage { get { return _DetailPageItem; } }
private readonly _hasContentImageItem __hasContentImageItem;
public _hasContentImageItem hasContentImage { get { return __hasContentImageItem; } }

#endregion

#region Boilerplate CustomItem Code

public DetailPagewithMiniStoriesItem(Item innerItem) : base(innerItem)
{
	_DetailPageItem = new DetailPageItem(innerItem);
	__hasContentImageItem = new _hasContentImageItem(innerItem);

}

public static implicit operator DetailPagewithMiniStoriesItem(Item innerItem)
{
	return innerItem != null ? new DetailPagewithMiniStoriesItem(innerItem) : null;
}

public static implicit operator Item(DetailPagewithMiniStoriesItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField MiniSharedStories
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Mini Shared Stories"]);
	}
}


public CustomMultiListField FullSharedStories
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Full Shared Stories"]);
	}
}


#endregion //Field Instance Methods
}
}