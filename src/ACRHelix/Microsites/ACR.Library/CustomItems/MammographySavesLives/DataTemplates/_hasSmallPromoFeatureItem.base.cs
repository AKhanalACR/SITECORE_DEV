using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;

namespace ACR.Library.MammographySavesLives.DataTemplates
{
public partial class _hasSmallPromoFeatureItem : CustomItem
{

public static readonly string TemplateId = "{2984A0F3-F73F-4771-9482-C0BA8F0BCBBB}";


#region Boilerplate CustomItem Code

public _hasSmallPromoFeatureItem(Item innerItem) : base(innerItem)
{

}

public static implicit operator _hasSmallPromoFeatureItem(Item innerItem)
{
	return innerItem != null ? new _hasSmallPromoFeatureItem(innerItem) : null;
}

public static implicit operator Item(_hasSmallPromoFeatureItem customItem)
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


public CustomGeneralLinkField PromoLink2
{
	get
	{
		return new CustomGeneralLinkField(InnerItem, InnerItem.Fields["Promo Link 2"]);
	}
}


public CustomTextField PromoLink2Title
{
	get
	{
		return new CustomTextField(InnerItem, InnerItem.Fields["Promo Link 2 Title"]);
	}
}


#endregion //Field Instance Methods
}
}