using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Home
{
public partial class ACRHomePageItem : CustomItem
{

public static readonly string TemplateId = "{45D07964-B564-45CB-82D7-7266574BD6B8}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }
private readonly RelatedProductsManualPageItem _RelatedProductsManualPageItem;
public RelatedProductsManualPageItem RelatedProductsManualPage { get { return _RelatedProductsManualPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public ACRHomePageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);
	_RelatedProductsManualPageItem = new RelatedProductsManualPageItem(innerItem);

}

public static implicit operator ACRHomePageItem(Item innerItem)
{
	return innerItem != null ? new ACRHomePageItem(innerItem) : null;
}

public static implicit operator Item(ACRHomePageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomMultiListField FeaturedSectionLinks
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Featured Section Links"]);
	}
}


public CustomImageField StaticImage
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Static Image"]);
	}
}


public CustomMultiListField CarouselItems
{
	get
	{
		return new CustomMultiListField(InnerItem, InnerItem.Fields["Carousel Items"]);
	}
}


#endregion //Field Instance Methods
}
}