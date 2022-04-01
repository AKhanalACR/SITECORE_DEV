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
public partial class DetailPageItem : CustomItem
{
public static readonly string TemplateId = "{A33FFB16-B879-4DDB-9998-79E7FB052BFF}";
#region Inherited Base Templates

private readonly _contentItem __contentItem;
public _contentItem content { get { return __contentItem; } }
private readonly _hasContentImageItem __hasContentImageItem;
public _hasContentImageItem hasContentImage { get { return __hasContentImageItem; } }
private readonly _hasPromotionsItem __hasPromotionsItem;
public _hasPromotionsItem hasPromotions { get { return __hasPromotionsItem; } }
private readonly _navigableItem __navigableItem;
public _navigableItem navigable { get { return __navigableItem; } }

#endregion

#region Boilerplate CustomItem Code

public DetailPageItem(Item innerItem) : base(innerItem)
{
	__contentItem = new _contentItem(innerItem);
	__hasContentImageItem = new _hasContentImageItem(innerItem);
	__hasPromotionsItem = new _hasPromotionsItem(innerItem);
	__navigableItem = new _navigableItem(innerItem);

}

public static implicit operator DetailPageItem(Item innerItem)
{
	return innerItem != null ? new DetailPageItem(innerItem) : null;
}

public static implicit operator Item(DetailPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}