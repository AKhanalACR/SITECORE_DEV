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
public partial class _promoItem : CustomItem
{
public static readonly string TemplateId = "{7859B431-83CE-4B02-ADC4-1D4CEDD2487D}";

#region Boilerplate CustomItem Code

public _promoItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _promoItem(Item innerItem)
{
	return innerItem != null ? new _promoItem(innerItem) : null;
}

public static implicit operator Item(_promoItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTextField PromoTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo Title"]);
	}
}


public CustomTextField PromoTeaser
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo Teaser"]);
	}
}


public CustomImageField PromoImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Promo Image"]);
	}
}


public CustomGeneralLinkField PromoLink
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Promo Link"]);
	}
}


public CustomTextField PromoLinkTitle
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo Link Title"]);
	}
}


#endregion //Field Instance Methods
}
}