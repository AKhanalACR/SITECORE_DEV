using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MSL.CustomItems.MammographySavesLives.DataTemplates
{
public partial class _hasTvAdsItem : CustomItem
{
public static readonly string TemplateId = "{291F543D-E7AB-417D-8494-2D2FEE023F64}";

#region Boilerplate CustomItem Code

public _hasTvAdsItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasTvAdsItem(Item innerItem)
{
	return innerItem != null ? new _hasTvAdsItem(innerItem) : null;
}

public static implicit operator Item(_hasTvAdsItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField TvAdsContent
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["TvAds Content"]);
	}
}


public CustomTextField TvAdsLabel
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["TvAds Label"]);
	}
}


#endregion //Field Instance Methods
}
}