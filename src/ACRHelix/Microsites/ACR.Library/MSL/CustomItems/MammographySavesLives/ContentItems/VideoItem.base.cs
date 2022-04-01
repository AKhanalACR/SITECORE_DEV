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
public partial class VideoItem : CustomItem
{
public static readonly string TemplateId = "{236D132B-986B-47F6-A790-4F816CD25CE8}";
#region Inherited Base Templates

private readonly _promoItem __promoItem;
public _promoItem promo { get { return __promoItem; } }

#endregion

#region Boilerplate CustomItem Code

public VideoItem(Item innerItem) : base(innerItem)
{
	__promoItem = new _promoItem(innerItem);

}

public static implicit operator VideoItem(Item innerItem)
{
	return innerItem != null ? new VideoItem(innerItem) : null;
}

public static implicit operator Item(VideoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField VideoID
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Video ID"]);
	}
}


#endregion //Field Instance Methods
}
}