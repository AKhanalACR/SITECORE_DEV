using System;
using Sitecore.Data.Items;
using System.Collections.Generic;
using Sitecore.Data.Fields;
using Sitecore.Web.UI.WebControls;
using CustomItemGenerator.Fields.LinkTypes;
using CustomItemGenerator.Fields.ListTypes;
using CustomItemGenerator.Fields.SimpleTypes;
using ACR.Library.CustomSitecore.CustomFields;
using ACR.Library.ACR.Base;

namespace ACR.Library.ACR.CodingSource
{
public partial class CodingSourceDetailPageItem : CustomItem
{

public static readonly string TemplateId = "{72EF5615-F611-4842-A7E2-FBC02E639E6B}";

#region Inherited Base Templates

private readonly TaxonomyContentItem _TaxonomyContentItem;
public TaxonomyContentItem TaxonomyContent { get { return _TaxonomyContentItem; } }
private readonly BasePageItem _BasePageItem;
public BasePageItem BasePage { get { return _BasePageItem; } }
private readonly RelatedDocumentsPageItem _RelatedDocumentsPageItem;
public RelatedDocumentsPageItem RelatedDocumentsPage { get { return _RelatedDocumentsPageItem; } }
private readonly RelatedProductsPageItem _RelatedProductsPageItem;
public RelatedProductsPageItem RelatedProductsPage { get { return _RelatedProductsPageItem; } }
private readonly WidgetPageItem _WidgetPageItem;
public WidgetPageItem WidgetPage { get { return _WidgetPageItem; } }

#endregion

#region Boilerplate CustomItem Code

public CodingSourceDetailPageItem(Item innerItem) : base(innerItem)
{
	_TaxonomyContentItem = new TaxonomyContentItem(innerItem);
	_BasePageItem = new BasePageItem(innerItem);
	_RelatedDocumentsPageItem = new RelatedDocumentsPageItem(innerItem);
	_RelatedProductsPageItem = new RelatedProductsPageItem(innerItem);
	_WidgetPageItem = new WidgetPageItem(innerItem);

}

public static implicit operator CodingSourceDetailPageItem(Item innerItem)
{
	return innerItem != null ? new CodingSourceDetailPageItem(innerItem) : null;
}

public static implicit operator Item(CodingSourceDetailPageItem customItem)
{
	return customItem != null ? customItem.InnerItem : null;
}

#endregion //Boilerplate CustomItem Code


#region Field Instance Methods


public CustomImageField Image
{
	get
	{
		return new CustomImageField(InnerItem, InnerItem.Fields["Image"]);
	}
}

public static string FieldName_Image 
{
	get
	{
		return "Image";
	}
} 


public CustomDateField PublicationDate
{
	get
	{
		return new CustomDateField(InnerItem, InnerItem.Fields["Publication Date"]);
	}
}

public static string FieldName_PublicationDate 
{
	get
	{
		return "Publication Date";
	}
} 


#endregion //Field Instance Methods
}
}