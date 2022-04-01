using System;
using ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.ContentItems
{
public partial class VideoPromoItem : CustomItem
{
public static readonly string TemplateId = "{9063D0F8-397F-4E7D-BB2A-4EF723633369}";
#region Inherited Base Templates

private readonly _promoItem __promoItem;
public _promoItem promo { get { return __promoItem; } }
private readonly VideoItem _VideoItem;
public VideoItem Video { get { return _VideoItem; } }

#endregion

#region Boilerplate CustomItem Code

public VideoPromoItem(Item innerItem) : base(innerItem)
{
	__promoItem = new _promoItem(innerItem);
	_VideoItem = new VideoItem(innerItem);

}

public static implicit operator VideoPromoItem(Item innerItem)
{
	return innerItem != null ? new VideoPromoItem(innerItem) : null;
}

public static implicit operator Item(VideoPromoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


#endregion //Field Instance Methods
}
}