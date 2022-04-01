using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.Education
{
public partial class EducationCatalogLandingPageItem : CustomItem
{

public static readonly string TemplateId = "{2B3BEF04-C540-4BBD-90DD-C3302ADA1F42}";

#region Inherited Base Templates

private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly BaseContentItem _BaseContentItem;
public BaseContentItem BaseContent { get { return _BaseContentItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public EducationCatalogLandingPageItem(Item innerItem) : base(innerItem)
{
	_BasePageItem = new BasePageItem(innerItem);
	_BaseContentItem = new BaseContentItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);

}

public static implicit operator EducationCatalogLandingPageItem(Item innerItem)
{
	return innerItem != null ? new EducationCatalogLandingPageItem(innerItem) : null;
}

public static implicit operator Item(EducationCatalogLandingPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomTreeListField SpotLightProducts
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Spot Light Products"]);
	}
}

public static string FieldName_SpotLightProducts 
{
	get
	{
		return "Spot Light Products";
	}
} 


public CustomTreeListField FeaturedCategories
{
	get
	{
		return new CustomTreeListField(InnerItem, InnerItem.Fields["Featured Categories"]);
	}
}

public static string FieldName_FeaturedCategories 
{
	get
	{
		return "Featured Categories";
	}
} 


#endregion //Field Instance Methods
}
}