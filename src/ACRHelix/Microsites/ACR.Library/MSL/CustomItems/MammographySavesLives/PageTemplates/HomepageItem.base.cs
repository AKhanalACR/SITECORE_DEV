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
public partial class HomepageItem : CustomItem
{
public static readonly string TemplateId = "{2062867E-3815-4EE1-BEAD-0BBBF42A59EA}";
#region Inherited Base Templates

private readonly _identityItem __identityItem;
public _identityItem identity { get { return __identityItem; } }
private readonly _navigableItem __navigableItem;
public _navigableItem navigable { get { return __navigableItem; } }
private readonly _hasFeaturedVideosItem __hasFeaturedVideosItem;
public _hasFeaturedVideosItem hasFeaturedVideos { get { return __hasFeaturedVideosItem; } }
private readonly _menuItem __menuItem;
public _menuItem menu { get { return __menuItem; } }
private readonly _hasSlidesItem __hasSlidesItem;
public _hasSlidesItem hasSlides { get { return __hasSlidesItem; } }
private readonly _hasPromotionsItem __hasPromotionsItem;
public _hasPromotionsItem hasPromotions { get { return __hasPromotionsItem; } }

#endregion

#region Boilerplate CustomItem Code

public HomepageItem(Item innerItem) : base(innerItem)
{
	__identityItem = new _identityItem(innerItem);
	__navigableItem = new _navigableItem(innerItem);
	__hasFeaturedVideosItem = new _hasFeaturedVideosItem(innerItem);
	__menuItem = new _menuItem(innerItem);
	__hasSlidesItem = new _hasSlidesItem(innerItem);
	__hasPromotionsItem = new _hasPromotionsItem(innerItem);

}

public static implicit operator HomepageItem(Item innerItem)
{
	return innerItem != null ? new HomepageItem(innerItem) : null;
}

public static implicit operator Item(HomepageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}