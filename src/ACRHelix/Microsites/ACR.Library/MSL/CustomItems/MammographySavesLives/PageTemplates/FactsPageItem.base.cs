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
public partial class FactsPageItem : CustomItem
{
public static readonly string TemplateId = "{0FE2AA6B-AF96-491A-B7E0-7F2CE0BACFCD}";
#region Inherited Base Templates

private readonly DetailPageItem _DetailPageItem;
public DetailPageItem DetailPage { get { return _DetailPageItem; } }
private readonly _hasFactsItem __hasFactsItem;
public _hasFactsItem hasFacts { get { return __hasFactsItem; } }
private readonly _hasFeaturedVideosItem __hasFeaturedVideosItem;
public _hasFeaturedVideosItem hasFeaturedVideos { get { return __hasFeaturedVideosItem; } }

#endregion

#region Boilerplate CustomItem Code

public FactsPageItem(Item innerItem) : base(innerItem)
{
	_DetailPageItem = new DetailPageItem(innerItem);
	__hasFactsItem = new _hasFactsItem(innerItem);
	__hasFeaturedVideosItem = new _hasFeaturedVideosItem(innerItem);

}

public static implicit operator FactsPageItem(Item innerItem)
{
	return innerItem != null ? new FactsPageItem(innerItem) : null;
}

public static implicit operator Item(FactsPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}